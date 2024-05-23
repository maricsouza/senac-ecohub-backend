using System.ComponentModel.DataAnnotations.Schema;

namespace Ecohub.Repository.Entidades
{
    [Table("PONTO_DE_COLETA_MATERIAIS")]
    public class MaterialPontoDeColetaEntidade
    {
        [Column("PONTO_COLETA_ID")]
        public string PontoDeColetaId { get; set; }

        [Column("MATERIAL_ID")]
        public int MeterialId { get; set; }
    }
}
