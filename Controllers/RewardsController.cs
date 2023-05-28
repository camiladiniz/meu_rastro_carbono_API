using MeuRastroCarbonoAPI.Infra;
using MeuRastroCarbonoAPI.Models.Enums;
using MeuRastroCarbonoAPI.Models.Payload.Rewards;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MeuRastroCarbonoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RewardsController : ControllerBase
    {
        private readonly DbContextClass _context;
        public RewardsController(DbContextClass context)
        {
            _context = context;
        }

        [HttpPost("user/{userId}")] // TODO: Authorize
        public async Task<IActionResult> GetUserRewards(Guid userId)
        {
            var rewards = new List<RewardsModel>();

            var waterEmissions = await _context.WaterSurveyAnswers.Where(w => w.UserId == userId).ToListAsync();
            var foodEmissions = await _context.FoodSurveyAnswers.Where(w => w.UserId == userId).ToListAsync();
            var transportEmissions = await _context.LocomotionSurveyAnswers.Where(w => w.UserId == userId).ToListAsync();
            var devicesEmissions = await _context.ElectronicSurveyAnswers.Where(w => w.UserId == userId).ToListAsync();

            var user = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
            var userByMoreThan2Weeks = user.RegisterDate <= DateTime.Now.AddDays(-7);
            var hadUsedPublicTransport = transportEmissions.Count() > 0 && (transportEmissions.Where(w => w.TransportType == TransportType.train || w.TransportType == TransportType.subway || w.TransportType == TransportType.bus).Any());
            var answeredForm = waterEmissions.Count() > 0 || foodEmissions.Count() > 0 || transportEmissions.Count() > 0 || devicesEmissions.Count() > 0;

            rewards.Add(new RewardsModel(title: "Começou a jornada", SurveyType.Generic, "Parabéns! Você respondeu seu primeiro formulário e começou a repensar seus hábitos!", waterEmissions.Where(w => w.EachShowerDuration <= 5).Any()));
            rewards.Add(new RewardsModel(title: "Utilizou transporte público", SurveyType.Locomotion, "Você utilizou tranporte público, ajudou o meio ambiente e economizou combustível", hadUsedPublicTransport));
            rewards.Add(new RewardsModel(title: "Rodízio ecológico", SurveyType.Locomotion, "Não utilizou carro com transporte por 1 semana.", userByMoreThan2Weeks && transportEmissions.Count() > 0 && !transportEmissions.Where(w => w.TransportType == TransportType.car).Any()));

            rewards.Add(new RewardsModel(title: "Quem anda também alcança!", SurveyType.Locomotion, "Evitou se locomover através de veículos poluentes optando por caminhar", transportEmissions.Where(w => w.TransportType == TransportType.bicycle).Any()));
            rewards.Add(new RewardsModel(title: "Pedalando para a vitória", SurveyType.Locomotion, "Evitou se locomover através de veículos poluentes optando por pedalar", transportEmissions.Where(w => w.TransportType == TransportType.bicycle).Any()));
            rewards.Add(new RewardsModel(title: "Mestre da eficiência", SurveyType.Water, "Parabéns por dominar o banho de 5 minutos ou menos", waterEmissions.Where(w => w.EachShowerDuration <= 5).Any()));

            return Ok(rewards.Where(r => r.IsActive == true));
        }
    }
}
