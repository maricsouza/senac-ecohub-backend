using Ecohub.Controllers.Models.Entrada;
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

        [HttpPost]
        public IActionResult AdicionarMaterial(MaterialViewModel material)
        {
            var response = _materialService.Adicionar(material);

            if(response == null)
            {
                return BadRequest(response);
            }

            return Ok();
        }

        [HttpGet("/buscarMateriais")]
        public async Task<IActionResult> BuscarMateriais()
        {
            var materiais = await _materialService.BuscarTodos();
            return Ok(materiais);

        }

        [HttpGet]
        public async Task<IActionResult> BuscarMaterial(int materialId)
        {
            var material = await _materialService.Buscar(materialId);
            return Ok(material);
        }

 

        [HttpPut]
        public IActionResult EditarMaterial(MaterialViewModel material, int materialId)
        {
            _materialService.Atualizar(material, materialId);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeletarMaterial (int materialId)
        {
            _materialService.Deletar(materialId);
            return Ok();
        }


    }
}