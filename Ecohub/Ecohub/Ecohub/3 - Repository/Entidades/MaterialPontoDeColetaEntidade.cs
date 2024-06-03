using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecohub.Repository.Entidades
{
    [Table("MATERIAIS_PONTOS_DE_COLETA")]
    public class MaterialPontoDeColetaEntidade
    {
        [Key]
        public int Id { get; set; }

        [Column("PONTO_DE_COLETA_ID")]
        public string PontoDeColetaId { get; set; }

        [Column("MATERIAL_ID")]
        public int MaterialId { get; set; }
    }
}
