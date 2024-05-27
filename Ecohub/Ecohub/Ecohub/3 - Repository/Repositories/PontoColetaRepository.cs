using Ecohub.Infra.Context;
using Ecohub.Repository.Entidades;
using Ecohub.Repository.Interfaces;

namespace Ecohub.Repository.Repositories
{
    public class PontoColetaRepository : IPontoColetaRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Add(PontoDeColetaEntidade pontoColeta)
        {
           _context.Add(pontoColeta);
           _context.SaveChanges();
        }

        public void Delete(PontoDeColetaEntidade pontoColeta)
        {
            _context.PontoColeta.Remove(pontoColeta);
            _context.SaveChanges();
        }

        public async Task<PontoDeColetaEntidade> Get(string pontoColetaId)
        {
            var pontoColeta = await _context.PontoColeta.FindAsync(pontoColetaId);

            return pontoColeta;
        }

        public async Task<List<PontoDeColetaEntidade>> GetAll()
        {
            var pontosColeta =  _context.PontoColeta.ToList();
            return pontosColeta;
        }

        public void Update(PontoDeColetaEntidade pontoColeta)
        {
            _context.PontoColeta.Update(pontoColeta);
            _context.SaveChanges();
        }
    }
}
