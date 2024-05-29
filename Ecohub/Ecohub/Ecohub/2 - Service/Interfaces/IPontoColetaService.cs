using Ecohub._1___Controllers.Models.Entrada;
using Ecohub._1___Controllers.Models.Retorno;
using Ecohub.Repository.Entidades;

namespace Ecohub.Service.Interfaces
{
    public interface IPontoColetaService
    {
        void Add(PontoColetaViewModel pontoColeta);
         Task<List<PontoDeColetaResponse>> GetAll();
        Task<PontoDeColetaResponse> Get(string pontoColetaId);
        void Update(PontoColetaViewModel pontoColeta, string pontoColetaId);
        void Delete(string pontoColetaId);
    }
}
