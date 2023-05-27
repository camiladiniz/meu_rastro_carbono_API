namespace MeuRastroCarbonoAPI.Models.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
    }
}
