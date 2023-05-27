namespace MeuRastroCarbonoAPI.Models.Response
{
    public class LoginResponse
    {
        public string? Token { get; set; }
        public string? Name { get; set; }
        public Guid? UserId { get; set; }
    }
}
