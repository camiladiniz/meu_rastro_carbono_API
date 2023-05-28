using MeuRastroCarbonoAPI.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeuRastroCarbonoAPI.Models.Entities.Surveys
{
    public class LocomotionSurveyAnswerEntity : SurveyAnswerBase
    {
        [Required]
        public TransportType TransportType { get; set; }

        [Required]
        public double DistanceInKm { get; set; }
        public string? MotorcycleFuel { get; set; }
        public string? MotorCycleMotor { get; set; }
        public string? CarFuel { get; set; }
        public string? CarMotor { get; set; }
        public string? CarElectricFuel { get; set; }
        public string? CarHybridFuel { get; set; }
        public double? CarHybridAutonomy { get; set; }
    }
}
