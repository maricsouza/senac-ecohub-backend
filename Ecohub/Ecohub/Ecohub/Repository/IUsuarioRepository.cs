using Ecohub.Models;

namespace Ecohub.Repository
{
    public interface IUsuarioRepository
    {
        public void Add(Usuario user);
        public List<Usuario> GetAll();
    }
}
