using Ecohub.Controllers.Models.Entrada;
using Ecohub.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecohub.Controllers
{
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
