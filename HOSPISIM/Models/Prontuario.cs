using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOSPISIM.Models
{
    public class Prontuario
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Número do Prontuário")]
        public int NumeroDoProntuario { get; set; }

        [Required(ErrorMessage = " O data é obrigatória")]
        [Display(Name = "Data de Abertura")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataDeAbertura { get; set; }

        [Required(ErrorMessage = "Observação é obrigatória")]
        [Display(Name = "Observações Gerais")]
        [StringLength(1000)]
        public string? ObservacoesGerais { get; set; }

        [Required]
        [Display(Name = "Paciente")]
        public Guid PacienteId { get; set; }

        [ForeignKey("PacienteId")]
        public Paciente? Paciente { get; set; }

        public ICollection<Atendimento>? Atendimentos { get; set; }
    }
}
