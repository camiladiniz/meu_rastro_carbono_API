using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuRastroCarbonoAPI.Models.Entities
{
    public class UserEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public DateTime? Birthdate { get; set; }

        public DateTime RegisterDate { get; set; } = DateTime.Now;

        public Guid EvolutionId { get; set; }

        [ForeignKey("EvolutionId")]
        public EvolutionEntity Evolution { get; set; }

        public virtual List<UserAchievementEntity> AchievementsAchieved { get; set; }
    }
}
