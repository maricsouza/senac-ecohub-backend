using System.ComponentModel.DataAnnotations;

namespace Ecohub._1___Controllers.Models.Entrada
{
    public class LoginViewModel
    {
 
        [Required(ErrorMessage = "Email obrigatorio")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "senha obrigatoria")]
        public string senha { get; set; }
      
    }
}
