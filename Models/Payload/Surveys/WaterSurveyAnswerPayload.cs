using System.ComponentModel.DataAnnotations;

namespace MeuRastroCarbonoAPI.Models.Payload
{
    public class WaterSurveyAnswerPayload
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTime ConsumptionDate { get; set; }

        [Required]
        public int ShowersAmount { get; set; }

        [Required]
        public int EachShowerDuration { get; set; }

        [Required]
        public double CarbonEmissionInKgCO2e { get; set; }
    }
}
