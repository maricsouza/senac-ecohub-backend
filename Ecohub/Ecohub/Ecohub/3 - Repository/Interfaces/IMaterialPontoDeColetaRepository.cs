using Ecohub.Repository.Entidades;

namespace Ecohub._3___Repository.Interfaces
{
    public interface IMaterialPontoDeColetaRepository
    {
        void Add(MaterialPontoDeColetaEntidade material);
        void Delete(MaterialPontoDeColetaEntidade materialPontoDeColeta);
        List<MaterialPontoDeColetaEntidade> GetAllById(string idPonto);
        MaterialPontoDeColetaEntidade GetOneById(string idPonto,int idMaterial);
    }
}
