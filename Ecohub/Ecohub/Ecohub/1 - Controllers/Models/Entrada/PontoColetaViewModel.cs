using Ecohub.Repository.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecohub._1___Controllers.Models.Entrada
{
    public class PontoColetaViewModel
    {
        public string Nome { get; set; }

        public string? Email { get; set; }

        public EnderecoEntidade? Endereco { get; set; }

        public string Imagem { get; set; }

        public string UsuarioId { get; set; }
    }
}
