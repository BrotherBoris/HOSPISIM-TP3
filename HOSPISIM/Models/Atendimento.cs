using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOSPISIM.Models
{
    public class Atendimento
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A data é obrigatória")]
        [Display(Name = "Data e Hora")]
        public DateTime DataEHora { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O status é obrigatório")]
        public string Status { get; set; }

        [Required(ErrorMessage = "O local é obrigatório")]
        public string Local { get; set; }

        [Display(Name = "Prontuário")]
        public Guid ProntuarioId { get; set; }

        [ForeignKey("ProntuarioId")]
        public Prontuario? Prontuario { get; set; }

        [Required]
        [Display(Name = "Paciente")]
        public Guid PacienteId { get; set; }

        [ForeignKey("PacienteId")]
        public Paciente? Paciente { get; set; }

        [Required]
        [Display(Name = "Profissional de Saúde")]
        public Guid ProfissionalDeSaudeId { get; set; }

        [ForeignKey("ProfissionalDeSaudeId")]
        public ProfissionalDeSaude? ProfissionalDeSaude { get; set; }


        //public ICollection<Prescricao>? Prescricoes { get; set; }
        //public ICollection<Exame>? Exames { get; set; }
        //public Internacao? Internacao { get; set; }
    }
}
