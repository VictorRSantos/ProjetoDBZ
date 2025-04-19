
using Microsoft.EntityFrameworkCore;
using ProjetoDBZ.src.Core.Entities;

namespace ProjetoDBZ.src.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}
        public DbSet<Personagem> DBZ { get; set; }        
    }
}