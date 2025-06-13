using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HOSPISIM.Models
{
    public class Exame
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O tipo do exame é obrigatório.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "A data de solicitação é obrigatória.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataDeSolicitacao { get; set; }

        [Required(ErrorMessage = "A data de realização é obrigatória.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataDeRealizacao { get; set; }

        [Required(ErrorMessage = "O resultado do exame é obrigatório.")]
        public string Resultado { get; set; }

        [Display(Name = "Atendimento")]
        public Guid AtendimentoId { get; set; }
        [ForeignKey("AtendimentoId")]
        public Atendimento? Atendimento { get; set; }

    }
}
