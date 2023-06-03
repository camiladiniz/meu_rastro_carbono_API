using System.ComponentModel.DataAnnotations;

namespace MeuRastroCarbonoAPI.Models.Payload
{
    public class AccountPayload
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string Password { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}
