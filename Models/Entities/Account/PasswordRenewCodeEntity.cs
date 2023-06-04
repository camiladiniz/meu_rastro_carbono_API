using System.ComponentModel.DataAnnotations;

namespace MeuRastroCarbonoAPI.Models.Entities.Account
{
    public class PasswordRenewCodeEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Code { get; set; }

        public bool Used { get; set; }
    }
}
