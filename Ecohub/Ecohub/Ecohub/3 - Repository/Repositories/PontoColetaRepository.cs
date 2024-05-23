using Ecohub.Infra.Context;
using Ecohub.Repository.Entidades;
using Ecohub.Repository.Interfaces;

namespace Ecohub.Repository.Repositories
{
    public class PontoColetaRepository : IPontoColetaRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Add(PontoDeColetaEntidade pontoDeColeta)
        {
            throw new NotImplementedException();
        }

        public void Delete(string pontoDeColetaId)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioEntidade> Get(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<UsuarioEntidade>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(PontoDeColetaEntidade user, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
