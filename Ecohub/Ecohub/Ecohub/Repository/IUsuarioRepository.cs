using Ecohub.Models;

namespace Ecohub.Repository
{
    public interface IUsuarioRepository
    {
        public void Add(UsuarioModel user);
        public List<UsuarioModel> GetAll();
    }
}
