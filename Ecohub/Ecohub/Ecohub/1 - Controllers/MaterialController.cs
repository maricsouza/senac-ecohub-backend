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
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var response = _materialService.Adicionar(material);

                return Ok(response);

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("/buscarMateriais")]
        public async Task<IActionResult> BuscarMateriais()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var materiais = await _materialService.BuscarTodos();
                return Ok(materiais);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> BuscarMaterial(int materialId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var material = await _materialService.Buscar(materialId);
                return Ok(material);

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

 

        [HttpPut]
        public IActionResult EditarMaterial(MaterialViewModel material, int materialId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                _materialService.Atualizar(material, materialId);
                return Ok();

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeletarMaterial (int materialId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                _materialService.Deletar(materialId);
                return Ok();

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}