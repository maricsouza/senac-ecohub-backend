using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ecohub.Repository.Entidades
{
    [Table("USUARIOS")]
    public class UsuarioEntidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } // GUID

        [Column("NOME")]
        public string Nome { get; set; }


        [Column("CPF")]
        public string CPF { get; set; }

        [Column("DATA_NASCIMENTO")]
        public DateOnly DataNascimento { get; set; }

        [Column("EMAIL")]
        public string Email { get; set; }

        [Column("SENHA")]
        public string Senha { get; set; }


        public UsuarioEntidade(string nome, string cPF, DateOnly dataNascimento, string email, string senha)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            CPF = cPF;
            DataNascimento = dataNascimento;
            Email = email;
            Senha = senha;
        }

        public UsuarioEntidade(string id, string nome, string cPF, DateOnly dataNascimento, string email, string senha)
        {
            Id = id;
            Nome = nome;
            CPF = cPF;
            DataNascimento = dataNascimento;
            Email = email;
            Senha = senha;
        }
    }
}
