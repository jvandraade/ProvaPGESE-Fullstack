using DesafioPGESE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioPGESE.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        

        public DbSet<Log> Logs { get; set; }
        public DbSet<DistribuicaoProcesso> DistribuicoesProcesso { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Prazo> Prazos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ProcessoJuridico> ProcessosJuridicos { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>().HasKey(l => l.Id);
            modelBuilder.Entity<DistribuicaoProcesso>().HasKey(l => l.NumUnico);
            modelBuilder.Entity<Documento>().HasKey(l => l.Id);
            modelBuilder.Entity<Prazo>().HasKey(l => l.Id);
            modelBuilder.Entity<Usuario>().HasKey(l => l.Id);
            modelBuilder.Entity<ProcessoJuridico>().HasKey(l => l.NumUnico);
        }

    }
}
