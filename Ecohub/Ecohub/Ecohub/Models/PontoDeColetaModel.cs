using Humanizer;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecohub.Models
{
    public class PontoDeColetaModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Numero { get; set; }
        public EnderecoModel Endereco { get; set; }
        public string UsuarioId { get; set; }
    }
}
