using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Ecohub.Repository.Entidades
{
    [Table("MATERIAIS")]
    public class MaterialEntidade
    {
        [Key] 
        public int Id { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }

    }
}
