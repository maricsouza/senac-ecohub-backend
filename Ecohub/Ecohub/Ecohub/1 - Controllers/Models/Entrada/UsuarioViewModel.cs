using System.ComponentModel.DataAnnotations;

namespace Ecohub.Controllers.Models.Entrada
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage ="O campo nome é obrigatório.")]
        [StringLength(70,ErrorMessage ="O nome deve ter no máximo 70 caracteres.")]
        [MinLength(3,ErrorMessage ="O nome deve ter no mínimo 3 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="O campo CPF é orbigatório.")]
        //CPF VALIDATOR
        public string CPF { get; set; }

        [Required(ErrorMessage ="A data de nascimento é obrigatória.")]
        // AGE VALIDATOR
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage ="O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage ="E-mail inválido, por favor inserir um e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="A senha é obrigatória.")]
        [MinLength(4,ErrorMessage ="A senha deve ter, no mínimo, 4 caracteres")]
        public string Senha { get; set; }
    }
}
