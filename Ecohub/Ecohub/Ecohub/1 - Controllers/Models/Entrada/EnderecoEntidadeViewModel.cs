using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecohub._1___Controllers.Models.Entrada
{
    public class EnderecoEntidadeViewModel
    {
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string? PontoReferencia { get; set; }
        public string CEP { get; set; }

    }
}