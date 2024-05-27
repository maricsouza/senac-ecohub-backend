using Ecohub._1___Controllers.Models.Entrada;
using Ecohub._3___Repository.Interfaces;
using Ecohub.Repository.Entidades;
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

        public void Add(PontoColetaViewModel pontoColeta)
        {

            var pontoColetaNovo = new PontoDeColetaEntidade(
               pontoColeta.Nome,
               pontoColeta.Email,
               pontoColeta.Numero,
               pontoColeta.Cidade,
               pontoColeta.Estado,
               pontoColeta.PontoReferencia,
               pontoColeta.CEP,
               pontoColeta.Imagem,
               pontoColeta.UsuarioId
               );      

            _pontoColetaRepository.Add(pontoColetaNovo);

        }

        public void Delete(string pontoColetaId)
        {
            var pontoColetaDelete = Get(pontoColetaId);
            _pontoColetaRepository.Delete(pontoColetaDelete.Result);
        }

        public Task<PontoDeColetaEntidade> Get(string pontoColetaId)
        {
           var ponto = _pontoColetaRepository.Get(pontoColetaId);
           return ponto;
        }

        public Task<List<PontoDeColetaEntidade>> GetAll()
        {
            var pontos = _pontoColetaRepository.GetAll();
            return pontos;
        }

        public void Update(PontoColetaViewModel pontoColeta, string pontoColetaId)
        {
   

            var pontoColetaAtt = new PontoDeColetaEntidade(
                pontoColetaId,
                pontoColeta.Nome,
                pontoColeta.Email,
                pontoColeta.Numero,
                pontoColeta.Cidade,
                pontoColeta.Estado,
                pontoColeta.PontoReferencia,
                pontoColeta.CEP,
                pontoColeta.Imagem,
                pontoColeta.UsuarioId
                );

            _pontoColetaRepository.Update(pontoColetaAtt);
            
        }
    }
}
