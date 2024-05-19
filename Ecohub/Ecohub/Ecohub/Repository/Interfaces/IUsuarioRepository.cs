using Ecohub.Controllers.Models.Entrada;
using Ecohub.Repository.Entidades;

namespace Ecohub.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        void Add(UsuarioEntidade user);
        Task<List<UsuarioEntidade>> GetAll();
        Task<UsuarioEntidade> Get(string userId);
        void Update(UsuarioViewModel user, string userId);
        void Delete(string userId);
    }
}
