using Ecohub._3___Repository.Interfaces;
using Ecohub.Controllers.Models.Entrada;
using Ecohub.Controllers.Models.Retorno;
using Ecohub.Repository.Entidades;
using Ecohub.Service.Interfaces;
using Newtonsoft.Json;

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
        public MaterialResponse Adicionar(MaterialViewModel material)
        {
            if (string.IsNullOrEmpty(material.Nome))
            {
                throw new Exception("O nome do material não pode estar vazio ou nulo.");
            }

            material.Descricao ??= string.Empty;
            
            var incluirMaterial = new MaterialEntidade(){ Nome = material.Nome, Descricao = material.Descricao};
            var response = _materialRepository.Add(incluirMaterial);

            var responseObject = new MaterialResponse()
            {
                Id = response.Id,
                Descricao = response.Descricao,
                Nome = response.Nome,
            };

            return responseObject;
        }
        public void Atualizar(MaterialViewModel material, int materialId)
        {
            if (string.IsNullOrEmpty(material.Nome))
            {
                throw new Exception("O nome do material não pode estar vazio ou nulo.");
            }

            material.Descricao ??= string.Empty;

            var atualizarMaterial = new MaterialEntidade() {  Nome = material.Nome, Descricao= material.Descricao, Id= materialId };
            _materialRepository.Update(atualizarMaterial);
        }

        public async void Deletar(int materialId)
        {
            var materialDelete = await Buscar(materialId) ?? throw new Exception("Não é possível deletar um material inexistente.");

            _materialRepository.Delete(materialDelete);
        }
    }
}
