using Ecohub.Controllers.Models.Entrada;
using Ecohub.Controllers.Models.Retorno;
using Ecohub.Repository.Entidades;
using Ecohub.Repository.Interfaces;
using Ecohub.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecohub.Controllers
{
    [ApiController]
    [Route("api/v1/materiais/[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService material) 
        { 
            _materialService = material;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarMateriais() 
        { 
            var materiais = await _materialService.BuscarTodos();
            return Ok(materiais);

        }

        [HttpGet]
        public IActionResult BuscarMaterial(int materialId)
        {
            var material = _materialService.Buscar(materialId);
            return Ok(material);
        }

        [HttpPost]
        public IActionResult AdicionarMaterial (MaterialViewModel material)
        {
            _materialService.Adicionar(material);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateMaterial (MaterialViewModel material, int materialId)
        {
            _materialService.Atualizar(material, materialId);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteMaterial (int materialId)
        {
            _materialService.Deletar(materialId);
            return Ok();
        }


    }
}