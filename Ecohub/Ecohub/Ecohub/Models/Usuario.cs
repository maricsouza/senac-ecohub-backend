
namespace Ecohub.Models
{
    public class Usuario
    {
        public string Id { get; set; } // GUID
    
        public string Nome { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Email { get; set; }
     
        public string Senha { get; set; }
    }
}
