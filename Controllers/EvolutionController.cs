using MeuRastroCarbonoAPI.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeuRastroCarbonoAPI.Controllers
{
    [Route("[controller]"), Authorize]
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

        [HttpGet]
        public async Task<IActionResult> EvolutionPerUser()
        {
            var userIdClaim = User.FindFirst("userId")?.Value ?? "";
            var userId = Guid.Parse(userIdClaim);

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
