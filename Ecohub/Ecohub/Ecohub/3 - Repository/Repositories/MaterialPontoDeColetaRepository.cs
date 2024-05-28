using Ecohub._3___Repository.Interfaces;
using Ecohub.Infra.Context;
using Ecohub.Repository.Entidades;

namespace Ecohub._3___Repository.Repositories
{
    public class MaterialPontoDeColetaRepository : IMaterialPontoDeColetaRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Add(MaterialPontoDeColetaEntidade material)
        {
            _context.MateriaisPontoDeColeta.Add(material);
            _context.SaveChanges();
        }

        public List<MaterialPontoDeColetaEntidade> GetAllById(string idPonto)
        {
            var response = _context.MateriaisPontoDeColeta.Where(ponto => ponto.PontoDeColetaId == idPonto).ToList();

            return response;
        }

        public MaterialPontoDeColetaEntidade GetOneById(string idPonto, int idMaterial)
        {
            var response = _context.MateriaisPontoDeColeta.Where(c => c.MaterialId.Equals(idMaterial)).ToList();
            var resp = response.Where(a => a.PontoDeColetaId.Equals(idPonto)).First();

            return resp;
        }

        public void Delete(MaterialPontoDeColetaEntidade materialPontoDeColeta)
        {
            _context.MateriaisPontoDeColeta.Remove(materialPontoDeColeta);
            _context.SaveChanges();
        }
    }
}
