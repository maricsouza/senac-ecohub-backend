using Ecohub.Controllers.Models.Entrada;
using Ecohub.Controllers.Models.Retorno;
using Ecohub.Repository.Entidades;

namespace Ecohub.Service.Interfaces
{
	public interface IMaterialService
	{
        MaterialResponse Adicionar(MaterialViewModel material);
		Task<List<MaterialEntidade>> BuscarTodos();
		Task<MaterialEntidade> Buscar(int materialId);
		void Atualizar(MaterialViewModel material, int materialId);
		void Deletar(int materialId);
	}
}