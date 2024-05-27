using System.ComponentModel.DataAnnotations;

namespace Ecohub.Controllers.Models.Entrada
{
    public class MaterialViewModel
    {
        [Required(ErrorMessage ="O nome do material é obrigatório.")]
        [StringLength(100, MinimumLength = 3,ErrorMessage = "O nome do material tem que ser maior do que 2 caracteres e menor do que 100.")]
        public string Nome { get; set; }

        public string Descricao { get; set; }


    }
}