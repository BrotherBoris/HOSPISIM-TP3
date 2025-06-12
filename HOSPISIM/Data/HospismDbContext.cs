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
    }
}
