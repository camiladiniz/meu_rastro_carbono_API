using MeuRastroCarbonoAPI.Infra;
using MeuRastroCarbonoAPI.Models.Entities;
using MeuRastroCarbonoAPI.Models.Entities.Account;
using MeuRastroCarbonoAPI.Models.Payload.UserAccount;
using MeuRastroCarbonoAPI.Models.Response;
using MeuRastroCarbonoAPI.Services.Interfaces;
using MeuRastroCarbonoAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeuRastroCarbonoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly DbContextClass _context;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;

        public AccountController(DbContextClass context, IConfiguration configuration, IEmailSender sender)
        {
            _context = context;
            _configuration = configuration;
            _emailSender = sender;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginPayload user)
        {
            if (user is null || user.Password.Length < 2 || user.Email.Length < 2)
            {
                return BadRequest("Dados inválidos");
            }

            var userEntity = await _context.Users.Where(u => u.Email == user.Email).FirstOrDefaultAsync();

            if (userEntity is null)
            {
                return BadRequest("Dados inválidos");
            }

            var validPassword = PasswordHelper.VerifyPassword(user.Password, userEntity.Password, userEntity.Salt);

            if (!validPassword)
            {
                return BadRequest("Dados inválidos");
            }

            var jwtSecret = _configuration["JWT:Secret"];
            var jwtIssuer = _configuration["JWT:ValidIssuer"];
            var jwtAudience = _configuration["JWT:ValidAudience"];
            var tokenString = AuthenticationHelper.GetTokenString(jwtSecret, jwtIssuer, jwtAudience, userEntity.Id.ToString());
            
            return Ok(new LoginResponse { Token = tokenString, Name = userEntity.Name, UserId = userEntity.Id });
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<AccountPayload>> Register(AccountPayload payload)
        {
            if(payload.Name.Length < 3 || payload.Name.Length > 30)
            {
                return BadRequest("Nome deve conter de 3 a 30 caracteres");
            }

            if (payload.Email.Length < 10 || payload.Email.Length > 50)
            {
                return BadRequest("Email deve conter de 10 a 50 caracteres");
            }

            if(!AuthenticationHelper.IsEmail(payload.Email))
            {
                return BadRequest("Informe um e-mail válido");
            }

            if (payload.Password.Length < 5 || payload.Password.Length > 15)
            {
                return BadRequest("Senha deve conter de 5 a 15 caracteres");
            }

            var userExists = await _context.Users.Where(u => u.Email == payload.Email).FirstOrDefaultAsync();

            if (userExists != null)
                return BadRequest("");

            var hash = PasswordHelper.HashPasword(payload.Password, out var salt);

            var userEntity = new UserEntity()
            {
                Name = payload.Name,
                Email = payload.Email,
                Password = hash,
                Salt = salt,
                Birthdate = payload.Birthdate,
                Evolution = new EvolutionEntity()
                {
                    Id = new Guid(),
                    TotalPontuation = 0,
                }
            };

            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();
            userEntity = await _context.Users.Where(u => u.Email == payload.Email).FirstOrDefaultAsync();

            var jwtSecret = _configuration["JWT:Secret"];
            var jwtIssuer = _configuration["JWT:ValidIssuer"];
            var jwtAudience = _configuration["JWT:ValidAudience"];
            var tokenString = AuthenticationHelper.GetTokenString(jwtSecret, jwtIssuer, jwtAudience, userEntity.Id.ToString());

            return Ok(new LoginResponse { Token = tokenString, Name = userEntity.Name, UserId = userEntity.Id });
        }

        [HttpPut]
        [Route("profile"), Authorize]
        public async Task<ActionResult> UpdateProfile(AccountEditPayload payload)
        {
            // Recuperar o ID do usuário do token JWT
            var userIdClaim = User.FindFirst("userId")?.Value ?? "";
            var userId = Guid.Parse(userIdClaim);

            var userEntity = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (userEntity is null)
            {
                return BadRequest();
            }

            userEntity.Name = payload.Name;
            userEntity.Email = payload.Email;

            _context.Users.Update(userEntity);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("forgot-password")]
        public async Task<ActionResult> SendCodeToEmail(AccountEditPayload payload)
        {
            var userEntity = await _context.Users.Where(u => u.Email == payload.Email).FirstOrDefaultAsync();

            if (userEntity is null)
            {
                return BadRequest();
            }

            // generate code
            var code = PasswordHelper.GenerateRandomCode(5);

            // send random code to user's email
            var fromEmail = _configuration["emailServer:fromEmail"];
            var smtpDomain = _configuration["emailServer:smtpDomain"];
            var smtpPort = _configuration["emailServer:smtpPort"];
            var fromEmailPassword = _configuration["emailServer:fromEmailPassword"];

            await _emailSender.SendRenewPasswordEmailAsync(fromEmail, userEntity.Email, smtpDomain, int.Parse(smtpPort), userEntity.Name, code, fromEmailPassword);

            // store code
            var codeEntity = new PasswordRenewCodeEntity()
            {
                Id = Guid.NewGuid(),
                UserId = userEntity.Id,
                Code = code,
                Used = false
            };

            _context.PasswordRenewCodes.Add(codeEntity);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("update-password/code/{code}")]
        public async Task<ActionResult> SendCodeToEmail(ForgotPasswordPayload payload, string code)
        {
            // validate received code
            var codeEntity = await _context.PasswordRenewCodes.Where(u => u.Code == code).FirstOrDefaultAsync();
            if (codeEntity is null || codeEntity.Used == true)
            {
                return NotFound();
            }

            var userEntity = await _context.Users.Where(u => u.Email == payload.Email).FirstOrDefaultAsync();
            if (userEntity is null || userEntity.Email != payload.Email)
            {
                return BadRequest();
            }

            // updating password
            var hash = PasswordHelper.HashPasword(payload.Password, out var salt);
            userEntity.Password = hash;
            userEntity.Salt = salt;
            _context.Users.Update(userEntity);
            
            // disabling code
            codeEntity.Used = true;
            _context.PasswordRenewCodes.Update(codeEntity);

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}