using MeuRastroCarbonoAPI.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeuRastroCarbonoAPI.Models.Entities.Surveys
{
    public class FoodSurveyAnswerEntity : SurveyAnswerBase
    {
        [Required]
        public int MealPortionsAmount { get; set; }

        [Required]
        public int MealsAmount { get; set; }
    }
}
