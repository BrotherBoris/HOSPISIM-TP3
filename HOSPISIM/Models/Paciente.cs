using System;
using System.ComponentModel.DataAnnotations;

namespace HOSPISIM.Models
{
    public enum Sexo
    {
        Masculino,
        Feminino,
        Outro
    }

    public enum EstadoCivil
    {
        [Display(Name = "Solteiro(a)")]
        Solteiro,
        [Display(Name = "Casado(a)")]
        Casado,
        [Display(Name = "Divorciado(a)")]
        Divorciado,
        [Display(Name = "Viúvo(a)")]
        Viuvo,
        [Display(Name = "Separado(a)")]
        Separado
    }

    public class Paciente
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = " O Nome do paciente é obrigatório")]
        [Display(Name = "Nome Completo")]
        [StringLength(80, ErrorMessage = "O nome do paciente não pode ser muito grande. 80 caracteres")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "A data de Nascimento é obrigatória")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O Sexo é obrigatório")]
        public Sexo Sexo { get; set; }

        [Required(ErrorMessage = "O tipo sanguíneo é obrigatório")]
        [Display(Name = "Tipo Sanguíneo")]
        public string TipoSanguineo { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O endereço de Email é obrigatório")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "O endereço é obrigatório")]
        [Display(Name = "Endereço Completo")]
        public string EnderecoCompleto { get; set; }

        [Display(Name = "Número Cartão SUS")]
        public string NumeroCartaoSUS { get; set; }

        [Required(ErrorMessage = "O estado civil é obrigatório")]
        [Display(Name = "Estado Civil")]
        public EstadoCivil EstadoCivil { get; set; }

        [Display(Name = "Possui Plano de Saúde?")]
        public bool PossuiPlanoSaude { get; set; }
    }
}
