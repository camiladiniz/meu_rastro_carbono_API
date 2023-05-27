using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuRastroCarbonoAPI.Models.Entities
{
    public class EvolutionHistoryEntity
    {
        [Key]
        public Guid Id { get; set; }

        public Guid EvolutionId { get; set; }

        [ForeignKey("EvolutionId")]
        public EvolutionEntity Evolution { get; set; }

        [Required]
        public int Pontuation { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; } = DateTime.Now;

    }
}
