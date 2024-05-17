
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecohub.Models
{
    [Table("USUARIOS")]
    public class UsuarioModel
    {
        public UsuarioModel()
        {
        }

        [Key]
        public string Id { get; set; } // GUID
    
        public string Nome { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Email { get; set; }
     
        public string Senha { get; set; }

        public UsuarioModel(string id, string nome, string cpf, DateTime dataNascimento, string email, string senha)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
            Email = email;
            Senha = senha;
        }
    }
}
