using System.ComponentModel.DataAnnotations;

namespace MeuRastroCarbonoAPI.Models.Entities
{
    public class SurveyEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
    }
}
