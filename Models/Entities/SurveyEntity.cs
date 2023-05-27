namespace MeuRastroCarbonoAPI.Models.Entities
{
    public class SurveyEntity
    {
        public Guid Id { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
    }
}
