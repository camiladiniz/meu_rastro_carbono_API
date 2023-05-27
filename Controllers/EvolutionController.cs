using MeuRastroCarbonoAPI.Infra;
using MeuRastroCarbonoAPI.Models.Payload;
using MeuRastroCarbonoAPI.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MeuRastroCarbonoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EvolutionController : ControllerBase
    {
        private readonly DbContextClass _context;
        private readonly IConfiguration _configuration;

        public EvolutionController(DbContextClass context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet("{userId}")] // TODO: Authorize
        public async Task<IActionResult> EvolutionPerUser(Guid userId)
        {
            var user = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }

            var evaluations = await _context.Evolutions.Where(u => u.Id == user.EvolutionId).FirstOrDefaultAsync();
            return Ok(evaluations);
        }
    }
}
