using Ecohub._1___Controllers.Models.Entrada;
using Ecohub.Controllers.Models.Entrada;
using Ecohub.Repository.Interfaces;
using Ecohub.Service;
using Ecohub.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecohub._1___Controllers
{
    [ApiController]
    [Route("api/v1/pontoColeta/[controller]")]
    public class PontoDeColetaController : Controller
    {
        private readonly IPontoColetaService _pontoColetaService;

        public PontoDeColetaController(IPontoColetaService pontoColetaService)
        {
            _pontoColetaService = pontoColetaService;
        }

        [HttpPost]
        public IActionResult AdicionarPontoColeta(PontoColetaViewModel ponto)
        {
            _pontoColetaService.Add(ponto);
            return Ok();

        }
        [HttpGet("/buscarPontosColeta")]
        public async Task<IActionResult> BuscarPontosColeta()
        {
            var todosPontos = await _pontoColetaService.GetAll();
            return Ok(todosPontos);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarPontoColeta(string pontoId)
        {
            var ponto = await _pontoColetaService.Get(pontoId);
            return Ok(ponto);
        }

        [HttpPut]
        public IActionResult EditarPontoColeta(PontoColetaViewModel ponto, string pontoId)
        {
            _pontoColetaService.Update(ponto, pontoId);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeltarPontoColeta(string pontoId)
        {

            _pontoColetaService.Delete(pontoId);
            return Ok();

        }

    }
}


