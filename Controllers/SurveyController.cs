using MeuRastroCarbonoAPI.Constants;
using MeuRastroCarbonoAPI.Infra;
using MeuRastroCarbonoAPI.Infra.Repositories;
using MeuRastroCarbonoAPI.Models.Entities.Surveys;
using MeuRastroCarbonoAPI.Models.Enums;
using MeuRastroCarbonoAPI.Models.Payload;
using MeuRastroCarbonoAPI.Models.Payload.Surveys;
using MeuRastroCarbonoAPI.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeuRastroCarbonoAPI.Controllers
{
    [Route("[controller]"), Authorize]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly DbContextClass _context;
        private readonly IConfiguration _configuration;
        private readonly EvolutionRepository _evolutionRepository;

        public SurveyController(DbContextClass context, IConfiguration configuration, EvolutionRepository evolutionRepository)
        {
            _context = context;
            _configuration = configuration;
            _evolutionRepository = evolutionRepository;
        }

        [HttpPost("answered")]
        public async Task<IActionResult> GetAnsweredSurveys([FromBody] SurveyAnsweredPayload payload)
        {
            var userIdClaim = User.FindFirst("userId")?.Value ?? "";
            var userId = Guid.Parse(userIdClaim);

            var surveysResponse = new SurveysPerDateResponse();

            surveysResponse.FoodSurvey = await _context.FoodSurveyAnswers.Where(s => s.UserId == userId && s.ConsumptionDate.Date == payload.Date.Date).AnyAsync();
            surveysResponse.LocomotionSurvey = await _context.LocomotionSurveyAnswers.Where(s => s.UserId == userId && s.ConsumptionDate.Date == payload.Date.Date).AnyAsync();
            surveysResponse.WaterSurvey = await _context.WaterSurveyAnswers.Where(s => s.UserId == userId && s.ConsumptionDate.Date == payload.Date.Date).AnyAsync();
            surveysResponse.ElectronicSurvey = await _context.ElectronicSurveyAnswers.Where(s => s.UserId == userId && s.ConsumptionDate.Date == payload.Date.Date).AnyAsync();
            return Ok(surveysResponse);
        }

        [HttpPost("water")]
        public async Task<IActionResult> WaterSurveyAnswer([FromBody] WaterSurveyAnswerPayload payload)
        {
            var userIdClaim = User.FindFirst("userId")?.Value ?? "";
            var userId = Guid.Parse(userIdClaim);

            var user = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }

            var answer = new WaterSurveyAnswerEntity() {
                Id = Guid.NewGuid(),
                UserId = userId,
                ConsumptionDate = payload.ConsumptionDate,
                SurveyType = SurveyType.Water,
                CarbonEmissionInKgCO2e = payload.CarbonEmissionInKgCO2e,
                ShowersAmount   = payload.ShowersAmount,
                EachShowerDuration = payload.EachShowerDuration,
            };

            _context.WaterSurveyAnswers.Add(answer);
            await _context.SaveChangesAsync();
            await _evolutionRepository.AddPontuation(user.Id, EvolutionPontuation.AnswerSurvey);
            return Ok();
        }

        [HttpPost("food")]
        public async Task<IActionResult> FoodSurveyAnswer([FromBody] FoodSurveyAnswerPayload payload)
        {
            var userIdClaim = User.FindFirst("userId")?.Value ?? "";
            var userId = Guid.Parse(userIdClaim);

            var user = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }

            var answer = new FoodSurveyAnswerEntity()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ConsumptionDate = payload.ConsumptionDate,
                SurveyType = SurveyType.Food,
                CarbonEmissionInKgCO2e = payload.CarbonEmissionInKgCO2e,
                MealPortionsAmount = payload.MealPortionsAmount,
                MealsAmount = payload.MealsAmount,
            };

            _context.FoodSurveyAnswers.Add(answer);
            await _context.SaveChangesAsync();
            await _evolutionRepository.AddPontuation(user.Id, EvolutionPontuation.AnswerSurvey);
            return Ok();
        }
        
        [HttpPost("electronics")] // TODO: Authorize
        public async Task<IActionResult> ElectronicsSurveyAnswer([FromBody] ElectronicSurveyAnswerPayload payload)
        {
            var userIdClaim = User.FindFirst("userId")?.Value ?? "";
            var userId = Guid.Parse(userIdClaim);

            var user = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }

            var answer = new ElectronicSurveyAnswerEntity()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ConsumptionDate = payload.ConsumptionDate,
                SurveyType = SurveyType.Electronics,
                CarbonEmissionInKgCO2e = payload.CarbonEmissionInKgCO2e,
                CellphoneUsageInHours = payload.CellphoneUsageInHours,
                ComputerTurnedOnInMinutes = payload.ComputerTurnedOnInMinutes,
                ComputerCoreType = payload.ComputerCoreType,
                ComputerCoresAmount = payload.ComputerCoresAmount,
                ComputerCPUModel = payload.ComputerCPUModel,
                ComputerGPUModel = payload.ComputerGPUModel,
                ComputerAvailableMemory = payload.ComputerAvailableMemory,
                StreamingUsageInMinutes = payload.StreamingUsageInMinutes,
                LampsOperationTime = payload.LampsOperationTime,
                LampType = payload.LampType,
                PhoneCarbonEmissionInKgCO2e = payload.PhoneCarbonEmissionInKgCO2e,
                ComputerCarbonEmissionInKgCO2e = payload.ComputerCarbonEmissionInKgCO2e,
                StreamingCarbonEmissionInKgCO2e = payload.StreamingCarbonEmissionInKgCO2e,
                LampCarbonEmissionInKgCO2e = payload.LampCarbonEmissionInKgCO2e
            };

            _context.ElectronicSurveyAnswers.Add(answer);
            await _context.SaveChangesAsync();
            await _evolutionRepository.AddPontuation(user.Id, EvolutionPontuation.AnswerSurvey);
            return Ok();
        }

        [HttpPost("locomotion")]
        public async Task<IActionResult> LocomotionSurveyAnswer([FromBody] LocomotionSurveyAnswerPayload payload)
        {
            var userIdClaim = User.FindFirst("userId")?.Value ?? "";
            var userId = Guid.Parse(userIdClaim);

            var user = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }

            var answer = new LocomotionSurveyAnswerEntity()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ConsumptionDate = payload.ConsumptionDate,
                DistanceInKm = payload.DistanceInKm,
                SurveyType = SurveyType.Locomotion,
                CarbonEmissionInKgCO2e = payload.CarbonEmissionInKgCO2e,
                TransportType = payload.TransportType,
                MotorcycleFuel = payload.MotorcycleFuel,
                MotorCycleMotor = payload.MotorCycleMotor,
                CarFuel = payload.CarFuel,
                CarMotor = payload.CarMotor,
                CarElectricFuel = payload.CarElectricFuel,
                CarHybridFuel = payload.CarHybridFuel,
                CarHybridAutonomy = payload.CarHybridAutonomy,
            };

            _context.LocomotionSurveyAnswers.Add(answer);
            await _evolutionRepository.AddPontuation(user.Id, EvolutionPontuation.AnswerSurvey);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
