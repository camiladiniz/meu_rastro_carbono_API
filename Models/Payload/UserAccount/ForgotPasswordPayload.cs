using System.ComponentModel.DataAnnotations;

namespace MeuRastroCarbonoAPI.Models.Payload.UserAccount
{
    public class ForgotPasswordPayload
    {
        [Required]
        public string Password { get; set; }
    }
}
