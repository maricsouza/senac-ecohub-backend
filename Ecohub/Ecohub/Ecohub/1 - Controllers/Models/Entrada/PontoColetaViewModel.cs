using Ecohub.Repository.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecohub._1___Controllers.Models.Entrada
{
    public class PontoColetaViewModel
    {
        [Required(ErrorMessage ="O nome do ponto de coleta é obrigatório")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage ="E-mail inválido, por favor insira um válido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "É obrigatório que se envie uma imagem")]
        public string Imagem { get; set; }

        [Required(ErrorMessage ="O número é obrigatório")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório")]
        public string Estado { get; set; }
        public string? PontoReferencia { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O identificador do usuário é obrigatório")]
        public string UsuarioId { get; set; }
    }

}
