using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<Cotacao> Cotacoes { get; set; }
        public DbSet<Operacao> Operacoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
