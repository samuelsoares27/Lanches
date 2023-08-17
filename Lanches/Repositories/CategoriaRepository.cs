using Lanches.Data;
using Lanches.Models;
using Lanches.Repositories.Interfaces;

namespace Lanches.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _dbContext;
        public CategoriaRepository(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Categoria> Categorias => _dbContext.Categorias;
    }
}
