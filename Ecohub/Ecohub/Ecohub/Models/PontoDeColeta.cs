using Humanizer;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecohub.Models
{
    public class PontoDeColeta
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Numero { get; set; }
        public Endereco Endereco { get; set; }
        public string UsuarioId { get; set; }
    }
}
