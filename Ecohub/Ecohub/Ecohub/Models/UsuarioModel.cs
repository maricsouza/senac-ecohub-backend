
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecohub.Models
{
    [Table("USUARIOS")]
    public class UsuarioModel
    {
        [Key]
        public string Id { get; set; } // GUID

        [Column("NOME")]
        public string Nome { get; set; }


        [Column("CPF")]
        public string CPF { get; set; }

        [Column("DATA_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Column("EMAIL")]
        public string Email { get; set; }

        [Column("SENHA")]
        public string Senha { get; set; }

        public UsuarioModel( string nome, string cPF, DateTime dataNascimento, string email, string senha)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            CPF = cPF;
            DataNascimento = dataNascimento;
            Email = email;
            Senha = senha;
        }
    }
}
