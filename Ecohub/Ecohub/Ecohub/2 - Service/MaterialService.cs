using Ecohub._3___Repository.Interfaces;
using Ecohub.Controllers.Models.Entrada;
using Ecohub.Controllers.Models.Retorno;
using Ecohub.Repository.Entidades;
using Ecohub.Service.Interfaces;

namespace Ecohub.Service
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService (IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;  
        }

        public async Task<List<MaterialEntidade>> BuscarTodos()
        {
            var material = await _materialRepository.GetAll();
            return material;
        }

        public async Task<MaterialEntidade> Buscar(int materialId)
        {
            var material = await _materialRepository.Get(materialId);
            return material;
        }
        public void Adicionar(MaterialViewModel material)
        {
            var incluirMaterial = new MaterialEntidade(){ Nome = material.Nome, Descricao = material.Descricao};
            _materialRepository.Add(incluirMaterial);
        }
        public void Atualizar(MaterialViewModel material, int materialId)
        {
            var atualizarMaterial = new MaterialEntidade() {  Nome = material.Nome, Descricao= material.Descricao, Id= materialId };
            _materialRepository.Update(atualizarMaterial);
        }

        public async void Deletar(int materialId)
        {
            var materialDelete = await Buscar(materialId);
            _materialRepository.Delete(materialDelete);
        }
    }
}
