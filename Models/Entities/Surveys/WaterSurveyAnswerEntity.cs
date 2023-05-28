using MeuRastroCarbonoAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuRastroCarbonoAPI.Models.Entities.Surveys
{
    public class WaterSurveyAnswerEntity : SurveyAnswerBase
    {
        [Required]
        public int ShowersAmount { get; set; }
        [Required]
        public int EachShowerDuration { get; set; }

    }
}
