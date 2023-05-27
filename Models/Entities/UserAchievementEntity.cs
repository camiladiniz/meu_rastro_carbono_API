using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeuRastroCarbonoAPI.Models.Entities
{
    public class UserAchievementEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; }

        [Required]
        public Guid AchievementId { get; set; }

        [ForeignKey("AchievementId")]
        public AchievementEntity Achievement { get; set; }
    }
}
