using HOSPISIM.Models;
using Microsoft.EntityFrameworkCore;

namespace HOSPISIM.Data
{
    public class DbSeed
    {
        public static void Initialize(HospismDbContext context)
        {
            context.Database.EnsureCreated();


            context.Database.Migrate();
            context.Pacientes.RemoveRange(context.Pacientes);
            context.ProfissionaisDeSaude.RemoveRange(context.ProfissionaisDeSaude);
            context.Especialidades.RemoveRange(context.Especialidades);

            context.SaveChanges();


            // SEED: Especialidades
            if (!context.Especialidades.Any())
            {
                var especialidades = new List<Especialidade>
                {
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Cardiologia" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Pediatria" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Ortopedia" }
                };

                context.Especialidades.AddRange(especialidades);
                context.SaveChanges();
            }

            // SEED: Profissionais de Saúde
            if (!context.ProfissionaisDeSaude.Any())
            {
                var especialidadeCardio = context.Especialidades.FirstOrDefault(e => e.Nome == "Cardiologia");

                var profissionais = new List<ProfissionalDeSaude>
            {
                new ProfissionalDeSaude
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Dr. João da Silva",
                    CPF = "12345678900",
                    Email = "joao@hospital.com",
                    Telefone = "11999990000",
                    RegistroConselho = "CRM12345",
                    TipoRegistro = "CRM",
                    DataAdmissao = DateTime.Now.AddYears(-2),
                    CargaHorariaSemanal = 40,
                    Turno = "Manhã",
                    Ativo = true,
                    EspecialidadeId = especialidadeCardio.Id
                }
            };

                context.ProfissionaisDeSaude.AddRange(profissionais);
                context.SaveChanges();
            }

            if (!context.Pacientes.Any())
            {
                var pacientes = new List<Paciente>
            {
                new Paciente
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Maria Oliveira",
                    CPF = "98765432100",
                    DataNascimento = new DateTime(1985, 5, 23),
                    Sexo = Sexo.Feminino,
                    TipoSanguineo = "O+",
                    Telefone = "11999887766",
                    Email = "maria@dominio.com",
                    EnderecoCompleto = "Rua das Flores, 123",
                    NumeroCartaoSUS = "123456789012345",
                    EstadoCivil = EstadoCivil.Casado,
                    PossuiPlanoSaude = true
                }
            };

                context.Pacientes.AddRange(pacientes);
                context.SaveChanges();
            }

        }

        
    }
}
