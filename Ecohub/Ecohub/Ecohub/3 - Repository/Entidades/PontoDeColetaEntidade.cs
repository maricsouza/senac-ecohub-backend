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

        //[Column("ENDERECO")]
        //public EnderecoEntidade Endereco { get; set; }

        [Column("IMAGEM")]
        public string Imagem { get; set; }

        [Column("USUARIO_ID")]
        public string UsuarioId { get; set; }

        public PontoDeColetaEntidade(string id, string nome, string? email, string imagem, string usuarioId)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Imagem = imagem;
            UsuarioId = usuarioId;
        }

        public PontoDeColetaEntidade(string nome, string? email, string imagem, string usuarioId)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Email = email;
            Imagem = imagem;
            UsuarioId = usuarioId;
        }
    }
}
