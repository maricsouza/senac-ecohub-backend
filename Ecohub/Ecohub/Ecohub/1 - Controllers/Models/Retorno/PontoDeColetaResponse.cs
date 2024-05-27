using Ecohub._1___Controllers.Models.Entrada;

namespace Ecohub._1___Controllers.Models.Retorno
{
    public class PontoDeColetaResponse
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string? Email { get; set; }
        public EnderecoEntidadeViewModel? Endereco { get; set; }
        public string Imagem { get; set; }
        public string UsuarioId { get; set; }
    }
}
