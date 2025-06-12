using System.ComponentModel.DataAnnotations;

namespace HOSPISIM.Models
{
    public class Especialidade
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome da especialidade é obrigatório.")]
        [StringLength(80, ErrorMessage = "O nome não pode ser muito grande. 80 caracteres")]
        public string Nome { get; set; }

        // Relacionamento
       public ICollection<ProfissionalDeSaude>? ProfissionaisDeSaude { get; set; }
    }
}
