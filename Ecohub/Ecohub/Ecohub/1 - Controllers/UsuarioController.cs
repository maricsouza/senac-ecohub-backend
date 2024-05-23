using Ecohub.Controllers.Models.Entrada;
using Ecohub.Repository.Entidades;
using Ecohub.Repository.Interfaces;
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
        public IActionResult Add(UsuarioViewModel user)
        {

            _usuarioService.Adicionar(user);
            return Ok();
        }

        [HttpGet]
        [Route("/BuscarTodos") ]
        public async Task<IActionResult> GetUsers()
        {
            
            var users = _usuarioService.BuscarTodos();
            return Ok(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string userId)
        {
            var user = await _usuarioService.Buscar(userId);
            return Ok(user);
        }

        [HttpPut]
        public IActionResult EditUser(UsuarioViewModel user, string userId)
        {
            _usuarioService.Atualizar(user, userId);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteUser(string userId) {

           _usuarioService.Deletar(userId);
            return Ok();
            
        }



    }
}
