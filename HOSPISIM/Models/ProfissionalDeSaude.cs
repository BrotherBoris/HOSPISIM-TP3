using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOSPISIM.Models
{
    public class ProfissionalDeSaude
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [Display(Name = "Nome Completo")]
        [StringLength(80, ErrorMessage = "O nome do profissional não pode ser muito grande. 80 caracteres")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O registro do conselho é obrigatório.")]
        [Display(Name = "Registro no Conselho")]
        public string RegistroConselho { get; set; }

        [Required(ErrorMessage = "O tipo de registro é obrigatório.")]
        [Display(Name = "Tipo de Registro")]
        public string TipoRegistro { get; set; }

        [Required(ErrorMessage = "A data de admissão é obrigatória.")]
        [Display(Name = "Data de Admissão")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataAdmissao { get; set; }

        [Required(ErrorMessage = "A carga horária semanal é obrigatória.")]
        [Display(Name = "Carga Horária Semanal")]
        public int CargaHorariaSemanal { get; set; }

        [Required(ErrorMessage = "O turno é obrigatório.")]
        public string Turno { get; set; }

        [Display(Name = "Está ativo?")]
        public bool Ativo { get; set; }

        // Chave estrangeira
        [Display(Name = "Especialidade")]
        public Guid EspecialidadeId { get; set; }

        [ForeignKey("EspecialidadeId")]
        public Especialidade? Especialidade { get; set; }
    }
}
