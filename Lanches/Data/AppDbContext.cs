using Lanches.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lanches.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;  
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options) 
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = _configuration.GetConnectionString(Environment.MachineName) ??
                _configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .HasData(
                    new Categoria
                    {
                        CategoriaId = 1,
                        CategoriaNome = "Natural",
                        Descricao = "Lanches feitos com ingredientes integrais"
                    },
                    new Categoria
                    {
                        CategoriaId = 2,
                        CategoriaNome = "Normal",
                        Descricao = "Lanches feitos com ingredientes integrais"
                    }
                );
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
    }
}
