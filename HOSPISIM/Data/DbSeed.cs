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

            context.Internacoes.RemoveRange(context.Internacoes);
            context.Prescricoes.RemoveRange(context.Prescricoes);
            context.Exame.RemoveRange(context.Exame);
            context.Prontuario.RemoveRange(context.Prontuario);
            context.Atendimento.RemoveRange(context.Atendimento);

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
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Ortopedia" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Neurologia" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Dermatologia" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Ginecologia" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Psiquiatria" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Oftalmologia" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Urologia" },
                    new Especialidade { Id = Guid.NewGuid(), Nome = "Endocrinologia" }
                };

                context.Especialidades.AddRange(especialidades);
                context.SaveChanges();
            }

            // SEED: Profissionais de Saúde
            if (!context.ProfissionaisDeSaude.Any())
            {
                var especialidadeCardio = context.Especialidades.FirstOrDefault(e => e.Nome == "Cardiologia");
                var especialidadeNeuro = context.Especialidades.FirstOrDefault(e => e.Nome == "Neurologia");
                var especialidadePedia = context.Especialidades.FirstOrDefault(e => e.Nome == "Pediatria");
                var especialidadeOrtop = context.Especialidades.FirstOrDefault(e => e.Nome == "Ortopedia");
                var especialidadeDermato = context.Especialidades.FirstOrDefault(e => e.Nome == "Dermatologia");
                var especialidadeGineco = context.Especialidades.FirstOrDefault(e => e.Nome == "Ginecologia");
                var especialidadePsiq = context.Especialidades.FirstOrDefault(e => e.Nome == "Psiquiatria");
                var especialidadeOftalmo = context.Especialidades.FirstOrDefault(e => e.Nome == "Oftalmologia");
                var especialidadeUro = context.Especialidades.FirstOrDefault(e => e.Nome == "Urologia");
                var especialidadeEndo = context.Especialidades.FirstOrDefault(e => e.Nome == "Endocrinologia");

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
                },
                new ProfissionalDeSaude
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Dra. Ana Paula Lima",
                    CPF = "22233344455",
                    Email = "ana.lima@hospital.com",
                    Telefone = "11988887777",
                    RegistroConselho = "CRM54321",
                    TipoRegistro = "CRM",
                    DataAdmissao = DateTime.Now.AddYears(-3),
                    CargaHorariaSemanal = 30,
                    Turno = "Tarde",
                    Ativo = true,
                    EspecialidadeId = especialidadeNeuro.Id
                },
                new ProfissionalDeSaude
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Dr. Roberto Mendes",
                    CPF = "33344455566",
                    Email = "roberto.mendes@hospital.com",
                    Telefone = "11987776655",
                    RegistroConselho = "CRM67890",
                    TipoRegistro = "CRM",
                    DataAdmissao = DateTime.Now.AddYears(-1),
                    CargaHorariaSemanal = 40,
                    Turno = "Manhã",
                    Ativo = true,
                    EspecialidadeId = especialidadePedia.Id
                },
                new ProfissionalDeSaude
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Dra. Camila Souza",
                    CPF = "44455566677",
                    Email = "camila.souza@hospital.com",
                    Telefone = "11986665544",
                    RegistroConselho = "CRM23456",
                    TipoRegistro = "CRM",
                    DataAdmissao = DateTime.Now.AddMonths(-18),
                    CargaHorariaSemanal = 36,
                    Turno = "Noite",
                    Ativo = true,
                    EspecialidadeId = especialidadeOrtop.Id
                },
                new ProfissionalDeSaude
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Dr. Fábio Rocha",
                    CPF = "55566677788",
                    Email = "fabio.rocha@hospital.com",
                    Telefone = "11985554433",
                    RegistroConselho = "CRM34567",
                    TipoRegistro = "CRM",
                    DataAdmissao = DateTime.Now.AddYears(-4),
                    CargaHorariaSemanal = 20,
                    Turno = "Tarde",
                    Ativo = true,
                    EspecialidadeId = especialidadeDermato.Id
                },
                new ProfissionalDeSaude
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Dra. Juliana Tavares",
                    CPF = "66677788899",
                    Email = "juliana.tavares@hospital.com",
                    Telefone = "11984443322",
                    RegistroConselho = "CRM45678",
                    TipoRegistro = "CRM",
                    DataAdmissao = DateTime.Now.AddYears(-2),
                    CargaHorariaSemanal = 32,
                    Turno = "Manhã",
                    Ativo = true,
                    EspecialidadeId = especialidadeGineco.Id
                },
                new ProfissionalDeSaude
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Dr. Henrique Silva",
                    CPF = "77788899900",
                    Email = "henrique.silva@hospital.com",
                    Telefone = "11983332211",
                    RegistroConselho = "CRM56789",
                    TipoRegistro = "CRM",
                    DataAdmissao = DateTime.Now.AddMonths(-6),
                    CargaHorariaSemanal = 40,
                    Turno = "Noite",
                    Ativo = true,
                    EspecialidadeId = especialidadePsiq.Id
                },
                new ProfissionalDeSaude
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Dra. Mariana Costa",
                    CPF = "88899900011",
                    Email = "mariana.costa@hospital.com",
                    Telefone = "11982221100",
                    RegistroConselho = "CRM67891",
                    TipoRegistro = "CRM",
                    DataAdmissao = DateTime.Now.AddYears(-1),
                    CargaHorariaSemanal = 38,
                    Turno = "Tarde",
                    Ativo = true,
                    EspecialidadeId = especialidadeOftalmo.Id
                },
                new ProfissionalDeSaude
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Dr. Ricardo Almeida",
                    CPF = "99900011122",
                    Email = "ricardo.almeida@hospital.com",
                    Telefone = "11981110099",
                    RegistroConselho = "CRM78912",
                    TipoRegistro = "CRM",
                    DataAdmissao = DateTime.Now.AddYears(-5),
                    CargaHorariaSemanal = 40,
                    Turno = "Manhã",
                    Ativo = true,
                    EspecialidadeId = especialidadeUro.Id
                },
                new ProfissionalDeSaude
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Dra. Patrícia Fernandes",
                    CPF = "00011122233",
                    Email = "patricia.fernandes@hospital.com",
                    Telefone = "11980009988",
                    RegistroConselho = "CRM89123",
                    TipoRegistro = "CRM",
                    DataAdmissao = DateTime.Now.AddYears(-2),
                    CargaHorariaSemanal = 40,
                    Turno = "Manhã",
                    Ativo = true,
                    EspecialidadeId = especialidadeEndo.Id
                }
            };

                context.ProfissionaisDeSaude.AddRange(profissionais);
                context.SaveChanges();
            }

            // SEED: Pacientes
            if (!context.Pacientes.Any())
            {
                var pacientes = new List<Paciente>
            {
                // 1
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
                },
                // 2
                new Paciente
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Carlos Souza",
                    CPF = "12345678900",
                    DataNascimento = new DateTime(1990, 3, 10),
                    Sexo = Sexo.Masculino,
                    TipoSanguineo = "A-",
                    Telefone = "11988776655",
                    Email = "carlos@dominio.com",
                    EnderecoCompleto = "Av. Paulista, 2000",
                    NumeroCartaoSUS = "987654321098765",
                    EstadoCivil = EstadoCivil.Solteiro,
                    PossuiPlanoSaude = false
                },
                // 3
                new Paciente
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Ana Clara Mendes",
                    CPF = "11122233344",
                    DataNascimento = new DateTime(1978, 8, 15),
                    Sexo = Sexo.Feminino,
                    TipoSanguineo = "B+",
                    Telefone = "11977665544",
                    Email = "ana@dominio.com",
                    EnderecoCompleto = "Rua Verde, 456",
                    NumeroCartaoSUS = "111222333444555",
                    EstadoCivil = EstadoCivil.Divorciado,
                    PossuiPlanoSaude = true
                },
                // 4
                new Paciente
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Marcos Vinícius Ferreira",
                    CPF = "12312312300",
                    DataNascimento = new DateTime(1982, 12, 5),
                    Sexo = Sexo.Masculino,
                    TipoSanguineo = "AB+",
                    Telefone = "11990001111",
                    Email = "marcos.ferreira@dominio.com",
                    EnderecoCompleto = "Rua São José, 321",
                    NumeroCartaoSUS = "111222333000111",
                    EstadoCivil = EstadoCivil.Casado,
                    PossuiPlanoSaude = true
                },
                // 5
                new Paciente
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Fernanda Lima Rocha",
                    CPF = "45645645600",
                    DataNascimento = new DateTime(1995, 6, 18),
                    Sexo = Sexo.Feminino,
                    TipoSanguineo = "O-",
                    Telefone = "11988889999",
                    Email = "fernanda.rocha@dominio.com",
                    EnderecoCompleto = "Av. Brasil, 785",
                    NumeroCartaoSUS = "444555666777888",
                    EstadoCivil = EstadoCivil.Solteiro,
                    PossuiPlanoSaude = false
                },
                // 6
                new Paciente
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Rafael Costa Martins",
                    CPF = "78978978900",
                    DataNascimento = new DateTime(2000, 3, 30),
                    Sexo = Sexo.Masculino,
                    TipoSanguineo = "A+",
                    Telefone = "11987776655",
                    Email = "rafael.martins@dominio.com",
                    EnderecoCompleto = "Rua das Palmeiras, 101",
                    NumeroCartaoSUS = "999888777666555",
                    EstadoCivil = EstadoCivil.Solteiro,
                    PossuiPlanoSaude = true
                },
                // 7
                new Paciente
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Luciana Alves Ribeiro",
                    CPF = "32132132100",
                    DataNascimento = new DateTime(1970, 1, 22),
                    Sexo = Sexo.Feminino,
                    TipoSanguineo = "B-",
                    Telefone = "11981112233",
                    Email = "luciana.ribeiro@dominio.com",
                    EnderecoCompleto = "Rua Nova Esperança, 50",
                    NumeroCartaoSUS = "888777666555444",
                    EstadoCivil = EstadoCivil.Viuvo,
                    PossuiPlanoSaude = false
                },
                // 8
                new Paciente
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Thiago Mendes Duarte",
                    CPF = "65465465400",
                    DataNascimento = new DateTime(1992, 9, 14),
                    Sexo = Sexo.Masculino,
                    TipoSanguineo = "O+",
                    Telefone = "11982223344",
                    Email = "thiago.duarte@dominio.com",
                    EnderecoCompleto = "Alameda das Rosas, 888",
                    NumeroCartaoSUS = "333222111000999",
                    EstadoCivil = EstadoCivil.Casado,
                    PossuiPlanoSaude = true
                },
                // 9
                new Paciente
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Juliana Souza Carvalho",
                    CPF = "98798798700",
                    DataNascimento = new DateTime(1988, 4, 11),
                    Sexo = Sexo.Feminino,
                    TipoSanguineo = "AB-",
                    Telefone = "11983334455",
                    Email = "juliana.carvalho@dominio.com",
                    EnderecoCompleto = "Rua Primavera, 67",
                    NumeroCartaoSUS = "777888999000111",
                    EstadoCivil = EstadoCivil.Separado,
                    PossuiPlanoSaude = false
                },
                // 10
                new Paciente
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = "Pedro Henrique Lima",
                    CPF = "11223344556",
                    DataNascimento = new DateTime(1975, 11, 3),
                    Sexo = Sexo.Masculino,
                    TipoSanguineo = "A-",
                    Telefone = "11984445566",
                    Email = "pedro.lima@dominio.com",
                    EnderecoCompleto = "Travessa do Sol, 12",
                    NumeroCartaoSUS = "112233445566778",
                    EstadoCivil = EstadoCivil.Divorciado,
                    PossuiPlanoSaude = true
                }

            };

                context.Pacientes.AddRange(pacientes);
                context.SaveChanges();
            }

            // SEED: Prontuario
            if (!context.Prontuario.Any())
            {
                var pacientes = context.Pacientes.Take(10).ToList();

                var prontuarios = new List<Prontuario>();

                int numeroInicial = 1;

                var observacoes = new List<string>
                {
                    "(1)Paciente com histórico de hipertensão controlada, sem uso atual de medicação.",
                    "(2)Referiu dores lombares constantes, principalmente ao final do dia.",
                    "(3)Paciente relatou cansaço excessivo nos últimos dias, sem febre ou dor localizada.",
                    "(4)Acompanhamento pós-operatório de apendicectomia, sem complicações.",
                    "(5)Apresenta sintomas leves de ansiedade, encaminhado para avaliação psicológica.",
                    "(6)Paciente diabético, mantendo controle glicêmico adequado com dieta e metformina.",
                    "(7)Reclamou de visão turva ao acordar. Encaminhado para oftalmologista.",
                    "(8)Histórico de enxaqueca. Iniciou novo tratamento com bons resultados.",
                    "(9)Sem queixas no momento. Consulta de rotina para renovação de receitas.",
                    "(10)Paciente com quadro gripal leve, orientado repouso e hidratação."
                };
                int i = 0;

                foreach (var paciente in pacientes)
                {
                    prontuarios.Add(new Prontuario
                    {
                        Id = Guid.NewGuid(),
                        NumeroDoProntuario = numeroInicial++,
                        DataDeAbertura = DateTime.Now.AddDays(-new Random().Next(10, 100)),
                        ObservacoesGerais = observacoes[i % observacoes.Count],
                        PacienteId = paciente.Id
                    });
                    i++;
                }

                context.Prontuario.AddRange(prontuarios);
                context.SaveChanges();
            }

            // SEED: Atendimento
            if (!context.Atendimento.Any())
            {
                var pacientes = context.Pacientes.ToList();
                var profissionais = context.ProfissionaisDeSaude.ToList();
                var prontuarios = context.Prontuario.ToList();

                var tipos = new[] { "Consulta", "Retorno", "Emergência", "Encaminhamento", "Avaliação" };
                var status = new[] { "Concluído", "Em andamento", "Cancelado", "Aguardando" };
                var locais = new[] { "Sala 1", "Sala 2", "UTI", "Consultório 5", "Pronto Atendimento" };

                var atendimentos = new List<Atendimento>();
                var rand = new Random();

                // Para cada paciente, criar um atendimento vinculado ao seu prontuário
                foreach (var paciente in pacientes)
                {
                    // Encontrar o prontuário desse paciente
                    var prontuario = prontuarios.FirstOrDefault(p => p.PacienteId == paciente.Id);

                    if (prontuario != null) // Verifique se existe prontuário
                    {
                        for (int i = 0; i < 1; i++) // gera 1 atendimento por paciente
                        {
                            atendimentos.Add(new Atendimento
                            {
                                Id = Guid.NewGuid(),
                                DataEHora = DateTime.Now.AddDays(-rand.Next(1, 60)).AddHours(rand.Next(8, 18)),
                                Tipo = tipos[rand.Next(tipos.Length)], 
                                Status = status[rand.Next(status.Length)], 
                                Local = locais[rand.Next(locais.Length)], 
                                PacienteId = paciente.Id, 
                                ProntuarioId = prontuario.Id, 
                                ProfissionalDeSaudeId = profissionais[rand.Next(profissionais.Count)].Id
                            });
                        }
                    }
                }

                context.Atendimento.AddRange(atendimentos);
                context.SaveChanges();
            }

            // SEED: Exame
            if (!context.Exame.Any())
            {
                var atendimentos = context.Atendimento.ToList();

                var tiposDeExame = new[] { "Hemograma", "Raio-X", "Ultrassonografia", "Eletrocardiograma", "Tomografia" };
                var resultados = new[] { "Normal", "Alterado", "Aguardando Resultado", "Em Análise", "Positivo" };

                var exames = new List<Exame>();
                var rand = new Random();

                // Gerar de 1 a 3 exames para cada atendimento
                foreach (var atendimento in atendimentos)
                {
                    for (int i = 0; i < rand.Next(1, 4); i++)
                    {
                        exames.Add(new Exame
                        {
                            Id = Guid.NewGuid(),
                            Tipo = tiposDeExame[rand.Next(tiposDeExame.Length)], 
                            DataDeSolicitacao = DateTime.Now.AddDays(-rand.Next(1, 30)), 
                            DataDeRealizacao = DateTime.Now.AddDays(-rand.Next(1, 30)),
                            Resultado = resultados[rand.Next(resultados.Length)], 
                            AtendimentoId = atendimento.Id
                        });
                    }
                }

                context.Exame.AddRange(exames);
                context.SaveChanges();
            }

            // SEED: Prescricoes
            if (!context.Prescricoes.Any())
            {
                var atendimentos = context.Atendimento.ToList();
                var profissionais = context.ProfissionaisDeSaude.ToList();

                var medicamentos = new[] { "Dipirona", "Amoxicilina", "Paracetamol", "Ibuprofeno", "Losartana", "Furosemida", "Omeprazol", "Loratadina", "Metformina", "AAS" };
                var dosagens = new[] { "500mg", "250mg", "200mg", "50mg", "20mg", "10mg", "100mg", "5mg", "400mg", "10mg/mL" };
                var frequencias = new[] { "A cada 8 horas", "A cada 12 horas", "Uma vez ao dia", "2 vezes ao dia", "3 vezes ao dia", "A cada 24 horas" };
                var viasAdministracao = new[] { "Oral", "Intravenosa", "Intramuscular", "Tópica", "Subcutânea" };
                var statusPrescricao = new[] { "Ativa", "Suspensa", "Encerrada" };
                var reacoesAdversas = new[] { "Náusea", "Tontura", "Dor abdominal", "Reação alérgica", "Efeito colateral não identificado", "Dores articulares" };

                var prescricoes = new List<Prescricao>();
                var rand = new Random();

                for (int i = 0; i < 10; i++)
                {
                    var atendimento = atendimentos[i];
                    var profissional = profissionais[i];

                    prescricoes.Add(new Prescricao
                    {
                        Id = Guid.NewGuid(),
                        Medicamento = medicamentos[rand.Next(medicamentos.Length)], 
                        Dosagem = dosagens[rand.Next(dosagens.Length)], 
                        Frequencia = frequencias[rand.Next(frequencias.Length)], 
                        ViaAdministracao = viasAdministracao[rand.Next(viasAdministracao.Length)], 
                        DataInicio = DateTime.Now.AddDays(-rand.Next(1, 30)), 
                        DataFim = DateTime.Now.AddDays(rand.Next(1, 15)), 
                        Observacoes = "Tomar com alimentos. " + (rand.Next(2) == 0 ? "Recomenda-se repouso." : "Evitar exposição ao sol."),
                        StatusPrescricao = statusPrescricao[rand.Next(statusPrescricao.Length)],
                        ReacoesAdversas = rand.Next(2) == 0 ? null : reacoesAdversas[rand.Next(reacoesAdversas.Length)],
                        AtendimentoId = atendimento.Id, 
                        ProfissionalId = profissional.Id
                    });
                }

                context.Prescricoes.AddRange(prescricoes);
                context.SaveChanges();
            }

            // SEED: Internacoes
            if (!context.Internacoes.Any())
            {
                var pacientes = context.Pacientes.ToList();
                var atendimentos = context.Atendimento.ToList();

                var motivosInternacao = new[] {
                    "Cirurgia programada",
                    "Acidente",
                    "Infecção respiratória",
                    "Fratura óssea",
                    "Exame especializado",
                    "Desidratação grave",
                    "Tratamento de câncer",
                    "Descompensação cardíaca",
                    "Pneumonia",
                    "Acidente vascular cerebral (AVC)"
                 };

                var leitos = new[] { "Leito 1", "Leito 2", "Leito 3", "Leito 4", "Leito 5" };
                var quartos = new[] { "Quarto 101", "Quarto 102", "Quarto 103", "Quarto 104", "Quarto 105" };
                var setores = new[] { "Clínica Médica", "Cardiologia", "Pediatria", "Ortopedia", "Neurologia", "Oncologia" };
                var planosSaude = new[] { "Unimed", "Amil", "Bradesco Saúde", "Cassi", "Itaú Saúde", "NotreDame Intermédica", "Saúde Caixa" };
                var statusInternacao = new[] { "Ativa", "Alta concedida", "Transferido", "Óbito" };

                var internacoes = new List<Internacao>();
                var rand = new Random();

                for (int i = 0; i < 10; i++)
                {
                    var paciente = pacientes[rand.Next(pacientes.Count)];
                    var atendimento = atendimentos[rand.Next(atendimentos.Count)];

                    var dataEntrada = DateTime.Now.AddDays(-rand.Next(1, 15));  
                    var previsaoAlta = dataEntrada.AddDays(rand.Next(2, 15)); 

                    internacoes.Add(new Internacao
                    {
                        Id = Guid.NewGuid(),
                        DataEntrada = dataEntrada,
                        PrevisaoAlta = previsaoAlta,
                        MotivoInternacao = motivosInternacao[rand.Next(motivosInternacao.Length)], 
                        Leito = leitos[rand.Next(leitos.Length)], 
                        Quarto = quartos[rand.Next(quartos.Length)],
                        Setor = setores[rand.Next(setores.Length)], 
                        PlanoSaudeUtilizado = planosSaude[rand.Next(planosSaude.Length)], 
                        ObservacoesClinicas = "Paciente em observação, apresentar sintomas de " + (rand.Next(2) == 0 ? "dificuldade respiratória" : "fortes dores abdominais") + ".",
                        StatusInternacao = statusInternacao[rand.Next(statusInternacao.Length)], 
                        PacienteId = paciente.Id, 
                        AtendimentoId = atendimento.Id
                    });
                }

                context.Internacoes.AddRange(internacoes);
                context.SaveChanges();
            }





        }



    }
    }
