using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOSPISIM.Models
{
    public class Prescricao
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = " O Nome do medicamento é obrigatório")]
        [StringLength(100)]
        public string Medicamento { get; set; }

        [Required(ErrorMessage = " A dosagem é obrigatório")]
        [StringLength(50)]
        public string Dosagem { get; set; }

        [Required(ErrorMessage = " A frequencia é obrigatório")]
        public string Frequencia { get; set; }

        [Required(ErrorMessage = " O modo de administração é obrigatório")]
        [Display(Name = "Via de Administração")]
        public string ViaAdministracao { get; set; }

        [Required(ErrorMessage = " A data de administração é obrigatório")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Inicio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInicio { get; set; }
        
        [Display(Name = "Data de termino")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataFim { get; set; }

        [Display(Name = "Observações")]
        [StringLength(500)]
        public string Observacoes { get; set; }

        [Required(ErrorMessage = " O status é obrigatório")]
        [Display(Name = "Status da Presquição")]
        public string StatusPrescricao { get; set; }  // Ex: Ativa, suspensa, encerrada

        [StringLength(500)]
        [Display(Name = "Reações adversas")]
        public string? ReacoesAdversas { get; set; }

        [Display(Name = "Atendimento")]
        public Guid AtendimentoId { get; set; }
        [ForeignKey("AtendimentoId")]
        public Atendimento? Atendimento { get; set; }  // Relacionamento com Atendimento

        [Display(Name = "Proficional")]
        public Guid ProfissionalId { get; set; }
        [ForeignKey("ProfissionalId")]
        public ProfissionalDeSaude? Profissional { get; set; }  // Relacionamento com Profissional
    }
}
