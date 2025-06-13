using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOSPISIM.Models
{
    public class Internacao
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Data de Entrada")]
        [Required(ErrorMessage = " A data de inicio é obrigatória")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DataEntrada { get; set; }

        [Display(Name = "Previsão de Alta")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? PrevisaoAlta { get; set; }

        [Display(Name = "Motivo da Internação")]
        [Required(ErrorMessage = " O motivo da internação é obrigatório")]
        public string MotivoInternacao { get; set; }

        [Required(ErrorMessage = " O leito é obrigatório")]
        public string Leito { get; set; }

        [Required(ErrorMessage = " O quarto é obrigatório")]
        public string Quarto { get; set; }

        [Required(ErrorMessage = " O setor é obrigatório")]
        public string Setor { get; set; }

        [Display(Name = "Plano de Saude Utilizado ")]
        [Required(ErrorMessage = " O plano de saude utilizado é obrigatório")]
        public string PlanoSaudeUtilizado { get; set; }  // Convênio utilizado, se houver

        [Display(Name = "Observações Clinicas")]
        [Required(ErrorMessage = " As Observações Clinicas são obrigatorias")]
        public string ObservacoesClinicas { get; set; }  // Anotações do médico ou enfermagem

        [Display(Name = "Status de Internação ")]
        [Required(ErrorMessage = " O Status de Internação é obrigatorio")]
        [StringLength(50)]
        public string StatusInternacao { get; set; }  // Status da internação: Ativa, Alta concedida, Transferido, Óbito



        [Display(Name = "Paciente")]
        public Guid PacienteId { get; set; }
        [ForeignKey("PacienteId")]
        public Paciente? Paciente { get; set; }  // Relacionamento com Paciente

        [Display(Name = "Atendimento")]
        public Guid AtendimentoId { get; set; }
        [ForeignKey("AtendimentoId")]
        public Atendimento? Atendimento { get; set; }  // Relacionamento com Atendimento
    }
}
