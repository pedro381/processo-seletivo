using Microsoft.EntityFrameworkCore;
using ProcessoSeletivo.Model;

namespace ProcessoSeletivo.Data
{
    public class ProcessoSeletivoContext : DbContext
    {
        public ProcessoSeletivoContext (DbContextOptions<ProcessoSeletivoContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pergunta>()
                .HasKey(p => p.PerguntaId);

            modelBuilder.Entity<Pergunta>()
                .Property(p => p.PerguntaId)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Pergunta> Pergunta { get; set; } = default!;
    }
}
