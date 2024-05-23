using Ecohub.Controllers.Models.Entrada;
using Ecohub.Repository.Entidades;

namespace Ecohub._3___Repository.Interfaces
{
    public interface IMaterialRepository
    {
        Task<List<MaterialEntidade>> GetAll();
        Task<MaterialEntidade> Get(int materialId);
        void Add(MaterialEntidade material);
        void Update(MaterialEntidade material);
        void Delete(MaterialEntidade material);
    }
}
