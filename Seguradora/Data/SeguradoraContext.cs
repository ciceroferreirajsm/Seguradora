using Microsoft.EntityFrameworkCore;
using Seguradora.Entities;

namespace Seguradora.Data
{
    public class SeguradoraContext : DbContext
    {
        public SeguradoraContext(DbContextOptions<SeguradoraContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Veiculo> Veiculo { get; set; }

        public DbSet<OficinaSegurada> OficinaSegurada { get; set; }
    }
}
