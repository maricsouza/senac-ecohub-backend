using Ecohub.Controllers.Models.Entrada;
using Ecohub.Repository.Entidades;

namespace Ecohub.Repository.Interfaces
{
    public interface IPontoColetaRepository
    {
        void Add(PontoDeColetaEntidade user);
        Task<List<UsuarioEntidade>> GetAll();
        Task<UsuarioEntidade> Get(string userId);
        void Update(PontoDeColetaEntidade user, string userId);
        void Delete(string userId);
    }
}
