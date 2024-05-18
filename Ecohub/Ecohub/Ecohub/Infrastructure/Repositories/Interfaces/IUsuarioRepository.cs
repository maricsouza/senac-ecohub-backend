using Ecohub.Models;
using Ecohub.Models.ViewModel;

namespace Ecohub.Infra.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        void Add(UsuarioModel user);
        Task<List<UsuarioModel>> GetAll();
        Task<UsuarioModel> Get(string userId);
        void Update(UsuarioViewModel user, string userId);
        void Delete(string userId);
    }
}
