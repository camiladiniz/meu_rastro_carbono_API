using System.ComponentModel.DataAnnotations;

namespace MeuRastroCarbonoAPI.Models.Entities
{
    public class EvolutionEntity
    {
        [Key]
        public Guid Id { get; set; }
        public int TotalPontuation { get; set; }

        public virtual List<EvolutionHistoryEntity> EvolutionHistory { get; set; }
    }
}
