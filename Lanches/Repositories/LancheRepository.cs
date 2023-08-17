using Lanches.Data;
using Lanches.Models;
using Lanches.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lanches.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _dbContext;
        public LancheRepository(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Lanche> Lanches => _dbContext.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => 
            _dbContext.Lanches.Where(l => l.IsLanchePreferido).Include(c => c.Categoria);

        public Lanche? GetLancheById(int id)
        {
            return _dbContext.Lanches.FirstOrDefault(l => l.LancheId == id);
        }
    }
}
