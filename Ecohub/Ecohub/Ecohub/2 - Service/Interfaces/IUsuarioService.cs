using Ecohub.Controllers.Models.Entrada;
using Ecohub.Repository.Entidades;

namespace Ecohub.Service.Interfaces
{
    public interface IUsuarioService
    {
        void Adicionar(UsuarioViewModel user);
        Task<List<UsuarioEntidade>> BuscarTodos();
        Task<UsuarioEntidade> Buscar(string userId);
        void Atualizar(UsuarioViewModel user, string userId);
        void Deletar(string userId);
    }
}
