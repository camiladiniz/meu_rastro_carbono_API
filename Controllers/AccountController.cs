using MeuRastroCarbonoAPI.Infra;
using MeuRastroCarbonoAPI.Models.Entities;
using MeuRastroCarbonoAPI.Models.Payload.UserAccount;
using MeuRastroCarbonoAPI.Models.Response;
using MeuRastroCarbonoAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MeuRastroCarbonoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly DbContextClass _context;
        private readonly IConfiguration _configuration;
        //private readonly IEmailSender _sender;

        public AccountController(DbContextClass context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginPayload user)
        {
            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }

            var userEntity = await _context.Users.Where(u => u.Email == user.Email).FirstOrDefaultAsync();

            if (userEntity is null)
            {
                return Unauthorized();
            }

            var validPassword = PasswordHelper.VerifyPassword(user.Password, userEntity.Password, userEntity.Salt);

            if (!validPassword)
            {
                return Unauthorized();
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
            var userExists = await _context.Users.Where(u => u.Email == payload.Email).FirstOrDefaultAsync();

            if (userExists != null)
                return BadRequest();

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


            // store code




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
        [Route("update-password"), Authorize]
        public async Task<ActionResult> SendCodeToEmail(AccountEditPayload payload)
        {
            // validate received code

            // update password

            // disable code

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
    }
}