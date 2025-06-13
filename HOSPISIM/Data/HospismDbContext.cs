using HOSPISIM.Models;
using Microsoft.EntityFrameworkCore;

namespace HOSPISIM.Data
{
    public class HospismDbContext : DbContext
    {
        public HospismDbContext(DbContextOptions<HospismDbContext> options)
            : base(options)
        {
        
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<ProfissionalDeSaude> ProfissionaisDeSaude { get; set; }
        public DbSet<HOSPISIM.Models.Atendimento> Atendimento { get; set; } = default!;
        public DbSet<HOSPISIM.Models.Prontuario> Prontuario { get; set; } = default!;
        public DbSet<HOSPISIM.Models.Exame> Exame { get; set; } = default!;
        public DbSet<Prescricao> Prescricoes { get; set; } = default!;
        public DbSet<Internacao> Internacoes { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Atendimento>()
                .HasOne(a => a.Prontuario)
                .WithMany(p => p.Atendimentos)
                .HasForeignKey(a => a.ProntuarioId)
                .OnDelete(DeleteBehavior.Restrict); // Impede cascata

            modelBuilder.Entity<Atendimento>()
                .HasOne(a => a.Paciente)
                .WithMany()
                .HasForeignKey(a => a.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Atendimento>()
                .HasOne(a => a.ProfissionalDeSaude)
                .WithMany()
                .HasForeignKey(a => a.ProfissionalDeSaudeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        

    }
}
