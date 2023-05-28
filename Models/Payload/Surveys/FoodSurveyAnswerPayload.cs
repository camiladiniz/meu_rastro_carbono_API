using MeuRastroCarbonoAPI.Models.Entities;
using MeuRastroCarbonoAPI.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeuRastroCarbonoAPI.Models.Payload.Surveys
{
    public class FoodSurveyAnswerPayload
    {
        public Guid UserId { get; set; }
        [Required]
        public DateTime ConsumptionDate { get; set; }

        [Required]
        public double CarbonEmissionInKgCO2e { get; set; }

        [Required]
        public int MealPortionsAmount { get; set; }

        [Required]
        public int MealsAmount { get; set; }
    }
}
