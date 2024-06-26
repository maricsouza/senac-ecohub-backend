﻿using Ecohub._1___Controllers.Models.Entrada;
using Ecohub.Controllers.Models.Entrada;
using Ecohub.Repository.Interfaces;
using Ecohub.Service;
using Ecohub.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
            try
            {
                _pontoColetaService.Add(ponto);
                return Ok();

            } catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }

        }
        [AllowAnonymous]
        [HttpGet("/buscarPontosColeta")]
        public async Task<IActionResult> BuscarPontosColeta()
        {
            try
            {
                var todosPontos = await _pontoColetaService.GetAll();
                return Ok(todosPontos);

            } catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> BuscarPontoColeta(string pontoId)
        {
            try
            {
                var ponto = await _pontoColetaService.Get(pontoId);
                return Ok(ponto);

            } catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("/buscarPorUsuario")]
        public async Task<IActionResult> BuscarPontoColetaUsuario(string usuarioId)
        {
            try
            {
                var ponto = await _pontoColetaService.GetPontoByUser(usuarioId);
                return Ok(ponto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditarPontoColeta(PontoColetaViewModel ponto, string pontoId)
        {
            try
            {
                _pontoColetaService.Update(ponto, pontoId);
                return Ok();

            } catch(Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeltarPontoColeta(string pontoId)
        {
            try
            {
                _pontoColetaService.Delete(pontoId);
                return Ok();
            } catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }

        }

    }
}


