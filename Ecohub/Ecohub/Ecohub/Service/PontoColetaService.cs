using Ecohub.Repository.Interfaces;
using Ecohub.Service.Interfaces;

namespace Ecohub.Service
{
    public class PontoColetaService : IPontoColetaService
    {
        private readonly IPontoColetaRepository _pontoColetaRepository;

        public PontoColetaService(IPontoColetaRepository pontoColetaRepository)
        {
            _pontoColetaRepository = pontoColetaRepository ?? throw new ArgumentException();
        }
    }
}
