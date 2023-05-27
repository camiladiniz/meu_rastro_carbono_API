using System.ComponentModel.DataAnnotations;

namespace MeuRastroCarbonoAPI.Models.Entities
{
    public class AchievementEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
