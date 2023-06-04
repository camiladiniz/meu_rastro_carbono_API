using System.ComponentModel.DataAnnotations;

namespace MeuRastroCarbonoAPI.Models.Entities.Account
{
    public class PasswordRenewCode
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
