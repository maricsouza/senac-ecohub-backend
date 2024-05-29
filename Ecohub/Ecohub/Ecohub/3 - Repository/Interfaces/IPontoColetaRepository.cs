using Ecohub.Controllers.Models.Entrada;
using Ecohub.Repository.Entidades;

namespace Ecohub.Repository.Interfaces
{
    public interface IPontoColetaRepository
    {
        string Add(PontoDeColetaEntidade pontoColeta);
        Task<List<PontoDeColetaEntidade>> GetAll();
        Task<PontoDeColetaEntidade> Get(string pontoColetaId);
        void Update(PontoDeColetaEntidade pontoColeta);
        void Delete(PontoDeColetaEntidade pontoColeta);
    }
}
