using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecohub.Repository.Entidades
{
    [Table("ENDERECOS_PONTOS_COLETA")]
    public class EnderecoEntidade
    {
        [Column("NUMERO")]
        public string Numero { get; set; }

        [Column("CIDADE")]
        public string Cidade { get; set; }

        [Column("ESTADO")]
        public string Estado { get; set; }

        [Column("PONTO_DE_REFERENCIA")]
        public string? PontoReferencia { get; set; }

        [Column("CEP")]
        public string CEP { get; set; }

        [Column("PONTOS_DE_COLETA_ID")]
        [Key]
        public string PontoColetaID { get; set; }
    }
}