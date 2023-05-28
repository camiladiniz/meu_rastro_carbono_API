using MeuRastroCarbonoAPI.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeuRastroCarbonoAPI.Models.Entities.Surveys
{
    public class SurveyAnswerBase
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime ConsumptionDate { get; set; }
        [Required]
        public SurveyType SurveyType { get; set; }
        [Required]
        public double CarbonEmissionInKgCO2e { get; set; }
    }
}
