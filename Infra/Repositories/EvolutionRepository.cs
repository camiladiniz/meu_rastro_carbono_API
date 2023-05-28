using MeuRastroCarbonoAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeuRastroCarbonoAPI.Infra.Repositories
{
    public class EvolutionRepository
    {
        private readonly DbContextClass _context;

        public EvolutionRepository(DbContextClass context)
        {
            _context = context;
        }

        public async Task AddPontuation(Guid userId, int points)
        {
            try {
                var user = await _context.Users.Where(e => e.Id == userId)
                    .Include(i => i.Evolution)
                    .FirstOrDefaultAsync();

                user.Evolution.TotalPontuation += points;
                _context.Evolutions.Update(user.Evolution);

                var activity = new EvolutionHistoryEntity()
                {
                    Id = Guid.NewGuid(),
                    EvolutionId = user.EvolutionId,
                    Pontuation = points
                };

                await _context.SaveChangesAsync();
            
            }catch(Exception ex) {
                var a = 0;
            }
        }
    }
}
