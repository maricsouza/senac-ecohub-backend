using Humanizer;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecohub.Repository.Entidades
{
    public class PontoDeColetaEntidade
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Numero { get; set; }
        public EnderecoEntidade Endereco { get; set; }
        public string UsuarioId { get; set; }
    }
}
