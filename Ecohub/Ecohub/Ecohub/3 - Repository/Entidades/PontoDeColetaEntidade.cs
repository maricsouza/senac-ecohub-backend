using Humanizer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecohub.Repository.Entidades
{
    [Table("PONTOS_DE_COLETA")]
    public class PontoDeColetaEntidade
    {
        [Key]
        [Column("ID")]
        public string Id { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("EMAIL")]
        public string? Email { get; set; }

        [Column("IMAGEM")]
        public string Imagem { get; set; }

        [Column("NUMERO")]
        public string Numero { get; set; }

        [Column("CIDADE")]
        public string Cidade { get; set; }

        [Column("ESTADO")]
        public string Estado { get; set; }

        [Column("PONTO_DE_REFERENCIA")]
        public string? PontoReferencia { get; set; }

        [Column("LATITUDE")]
        public string Latitude { get; set; }

        [Column("LONGITUDE")]
        public string Longitude { get; set; }

        [Column("CEP")]
        public string CEP { get; set; }

        [Column("USUARIO_ID")]
        [ForeignKey("USUARIO_ID")]
        public string UsuarioId { get; set; }

        public PontoDeColetaEntidade(string nome, string? email, string imagem, string numero, string cidade, string estado, string? pontoReferencia, string cEP, string usuarioId, string latitude, string longitude)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Email = email;
            Imagem = imagem;
            Numero = numero;
            Cidade = cidade;
            Longitude = longitude;
            Latitude = latitude;
            Estado = estado;
            PontoReferencia = pontoReferencia;
            CEP = cEP;
            UsuarioId = usuarioId;
        }

        public PontoDeColetaEntidade(string id, string nome, string? email, string imagem, string numero, string cidade, string estado, string? pontoReferencia, string cEP, string usuarioId, string latitude, string longitude)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Imagem = imagem;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            PontoReferencia = pontoReferencia;
            CEP = cEP;
            UsuarioId = usuarioId;
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
