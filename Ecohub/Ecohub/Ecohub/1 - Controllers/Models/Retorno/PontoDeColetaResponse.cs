using Ecohub._1___Controllers.Models.Entrada;

namespace Ecohub._1___Controllers.Models.Retorno
{
    public class PontoDeColetaResponse
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string? Email { get; set; }
        public string Numero { get; set; }
        public string Imagem { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string? PontoReferencia { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string CEP { get; set; }
        public string UsuarioId { get; set; }
        public List<MaterialPontoColetaResponse> Materiais { get; set; }
    }
}
