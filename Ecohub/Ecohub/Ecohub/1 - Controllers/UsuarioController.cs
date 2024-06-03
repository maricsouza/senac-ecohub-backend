using Ecohub._1___Controllers.Models.Entrada;
using Ecohub.Controllers.Models.Entrada;
using Ecohub.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecohub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/usuario/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService ?? throw new ArgumentException();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AdicionarUsuario(UsuarioViewModel user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                _usuarioService.Adicionar(user);
                return Ok();

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        [AllowAnonymous]
        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel login)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var token = _usuarioService.Login(login).Result;
                if(token == null)
                  return StatusCode(401, "Senha ou usuario invalido");

                return Ok(token);
            }
            catch
            {
                return StatusCode(500, "Internal error");
            }
        }

        [AllowAnonymous]
        [HttpGet("/buscarUsuarios")]
        public async Task<IActionResult> BuscarUsuarios()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var users = await _usuarioService.BuscarTodos();
                return Ok(users);

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> BuscarUsuario(string userId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var user = await _usuarioService.Buscar(userId);
                return Ok(user);

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditarUsuario(UsuarioViewModel user, string userId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                _usuarioService.Atualizar(user, userId);
                return Ok();

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeltarUsuario(string userId) 
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                _usuarioService.Deletar(userId);
                return Ok();

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
