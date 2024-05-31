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

        [HttpPost]
        public IActionResult AdicionarUsuario(UsuarioViewModel user)
        {

            _usuarioService.Adicionar(user);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel login)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var token = _usuarioService.Login(login).Result;
                if(token == "")
                  return StatusCode(401, "Senha ou usuario invalido");

                return Ok(token);
            }
            catch
            {
                return StatusCode(500, "Internal error");
            }
        }

        [HttpGet("/buscarUsuarios")]
        public async Task<IActionResult> BuscarUsuarios()
        {          
            var users = await _usuarioService.BuscarTodos();
            return Ok(users);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarUsuario(string userId)
        {
            var user = await _usuarioService.Buscar(userId);
            return Ok(user);
        }

        [HttpPut]
        public IActionResult EditarUsuario(UsuarioViewModel user, string userId)
        {
            _usuarioService.Atualizar(user, userId);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeltarUsuario(string userId) {

           _usuarioService.Deletar(userId);
            return Ok();
            
        }



    }
}
