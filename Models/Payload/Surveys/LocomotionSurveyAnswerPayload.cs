using MeuRastroCarbonoAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MeuRastroCarbonoAPI.Models.Payload.Surveys
{
    public class LocomotionSurveyAnswerPayload
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTime ConsumptionDate { get; set; }

        [Required]
        public double CarbonEmissionInKgCO2e { get; set; }

        [Required]
        public double DistanceInKm { get; set; }

        [Required]
        public TransportType TransportType { get; set; }

        public string? MotorcycleFuel { get; set; }
        public string? MotorCycleMotor { get; set; }
        public string? CarFuel { get; set; }
        public string? CarMotor { get; set; }
        public string? CarElectricFuel { get; set; }
        public string? CarHybridFuel { get; set; }
        public double? CarHybridAutonomy { get; set; }
    }
}
