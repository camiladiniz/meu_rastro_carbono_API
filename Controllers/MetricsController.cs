using MeuRastroCarbonoAPI.Infra.Repositories;
using MeuRastroCarbonoAPI.Infra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MeuRastroCarbonoAPI.Models.Payload.Surveys;
using MeuRastroCarbonoAPI.Models.Response;
using MeuRastroCarbonoAPI.Models.Payload.Metrics;
using MeuRastroCarbonoAPI.Models.Enums;
using MeuRastroCarbonoAPI.Models.Payload.Tips;
using MeuRastroCarbonoAPI.Constants;
using static MeuRastroCarbonoAPI.Models.Payload.Tips.TipsModel;

namespace MeuRastroCarbonoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MetricsController : ControllerBase
    {
        private readonly DbContextClass _context;

        public MetricsController(DbContextClass context)
        {
            _context = context;
        }

        [HttpPost("user/{userId}")] // TODO: Authorize
        public async Task<IActionResult> GetMetrics(Guid userId)
        {
            var payload = new MetricsPayload()
            {
                FinalDate = DateTime.UtcNow,
                InitialDate = DateTime.UtcNow.AddDays(-7),
            };

            var waterEmissions = await _context.WaterSurveyAnswers.Where(w => w.UserId == userId && w.ConsumptionDate >= payload.InitialDate && w.ConsumptionDate <= payload.FinalDate).ToListAsync();
            var foodEmissions = await _context.FoodSurveyAnswers.Where(w => w.UserId == userId && w.ConsumptionDate >= payload.InitialDate && w.ConsumptionDate <= payload.FinalDate).ToListAsync();
            var transportEmissions = await _context.LocomotionSurveyAnswers.Where(w => w.UserId == userId && w.ConsumptionDate >= payload.InitialDate && w.ConsumptionDate <= payload.FinalDate).ToListAsync();
            var devicesEmissions = await _context.ElectronicSurveyAnswers.Where(w => w.UserId == userId && w.ConsumptionDate >= payload.InitialDate && w.ConsumptionDate <= payload.FinalDate).ToListAsync();

            #region waterEmission
            var emisionByShower = waterEmissions.Sum(w => w.CarbonEmissionInKgCO2e);
            var showerAmount = waterEmissions.Sum(w => w.ShowersAmount);
            if (showerAmount == 0)
            {
                showerAmount = 1;
            }
            var showerDurationMedia = waterEmissions.Sum(w => w.EachShowerDuration * w.ShowersAmount) / showerAmount;
            #endregion

            #region transportEmission
            var emissionsByCar = transportEmissions.Where(t => t.TransportType == TransportType.car).ToList();
            #endregion

            var metrics = new MetricsResponse()
            {
                ShowersMedia = showerDurationMedia,
                ShowersEmissionByGPerCO2 = emisionByShower * 1000,
                CarDistanceTraveled = emissionsByCar.Sum(c => c.DistanceInKm),
                CarEmissionByGPerCO2 = emissionsByCar.Sum(c => c.CarbonEmissionInKgCO2e) * 1000,
                FoodEmissionByGPerCO2 = foodEmissions.Sum(c => c.CarbonEmissionInKgCO2e) * 1000,
                PhoneInChargeInHours = devicesEmissions.Sum(d => d.CellphoneUsageInHours),
                PhoneEmissionByGPerCO2 = devicesEmissions.Sum(d => d.PhoneCarbonEmissionInKgCO2e) * 1000,
                LampsEmissionByGPerCO2 = devicesEmissions.Sum(d => d.LampCarbonEmissionInKgCO2e) * 1000,
                LampsOperationTimeInHours = devicesEmissions.Sum(d => d.LampsOperationTime),
                ComputerEmissionByGPerCO2 = devicesEmissions.Sum(d => d.ComputerCarbonEmissionInKgCO2e) * 1000,
                ComputerTurnedOnInMinutes = devicesEmissions.Sum(d => d.ComputerTurnedOnInMinutes),
                StreamingEmissionByGPerCO2 = devicesEmissions.Sum(d => d.StreamingCarbonEmissionInKgCO2e) * 1000,
                StreamingTimeInHours = devicesEmissions.Sum(d => d.StreamingUsageInMinutes) / 60,
            };
            metrics.TotalCarbonEmissionsInG = metrics.ShowersEmissionByGPerCO2 + metrics.CarEmissionByGPerCO2 + metrics.FoodEmissionByGPerCO2 + metrics.PhoneEmissionByGPerCO2 + metrics.LampsEmissionByGPerCO2 + metrics.ComputerEmissionByGPerCO2 + metrics.StreamingEmissionByGPerCO2;

            #region tree compensation
            var emissionInKg = metrics.TotalCarbonEmissionsInG / 1000;
            var fatorMataAtlanticaArvorePorKgDeCO2Por30Anos = 130;
            #endregion

            metrics.TreesAmountToCompensate = System.Convert.ToInt32(emissionInKg / fatorMataAtlanticaArvorePorKgDeCO2Por30Anos);
            metrics.TreesAmountToCompensateInAYear = System.Convert.ToInt32((emissionInKg * 365) / fatorMataAtlanticaArvorePorKgDeCO2Por30Anos);

            return Ok(metrics);
        }

        [HttpPost("tips/{userId}")] // TODO: Authorize
        public async Task<IActionResult> GetTips(Guid userId)
        {
            var waterTips = TipsDataset.waterTips;
            var foodTips = TipsDataset.foodTips;
            var electronicsTips = TipsDataset.electronicsTips;
            var locomotionTips = TipsDataset.locomotionTips;

            var tips = new List<TipsModel>();
            var waterEmissions = await _context.WaterSurveyAnswers.Where(w => w.UserId == userId).ToListAsync();
            var foodEmissions = await _context.FoodSurveyAnswers.Where(w => w.UserId == userId).ToListAsync();
            var transportEmissions = await _context.LocomotionSurveyAnswers.Where(w => w.UserId == userId).ToListAsync();
            var devicesEmissions = await _context.ElectronicSurveyAnswers.Where(w => w.UserId == userId).ToListAsync();

            // customized tips electronics
            var usesIncandendescentLamp = devicesEmissions.Where(e => e.LampType != "LED").Any();
            if(usesIncandendescentLamp)
            {
                tips.AddRange(electronicsTips.Where(c => c.Category == TipCategory.IncandescentLamp));
            }

            // customized tips locomotion
            var haveCar = transportEmissions.Where(e => e.TransportType == TransportType.car).Any();
            if(haveCar)
            {
                tips.AddRange(locomotionTips.Where(c => c.Category == TipCategory.Car).Take(2));

                var usesEtanol = transportEmissions.Where(e => e.CarFuel == "Etanol").Any();
                if(usesEtanol)
                {
                    tips.AddRange(locomotionTips.Where(c => c.Category == TipCategory.EtanolFuelCar));
                }
            }

            //generics tips
            int numberOfItemsToSelect = 2;
            Random random = new Random();

            tips.AddRange(waterTips.Take(numberOfItemsToSelect));
            tips.AddRange(foodTips.Take(numberOfItemsToSelect));
            tips.AddRange(electronicsTips.Where(c => c.Category == TipCategory.Cellphone));
            tips.AddRange(electronicsTips.Where(c => c.Category == TipCategory.Electricity));

            return Ok(tips.OrderBy(x => random.Next()).ToList());
        }
    }
}
