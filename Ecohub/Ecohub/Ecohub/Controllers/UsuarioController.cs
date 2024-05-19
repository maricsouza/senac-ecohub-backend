using Ecohub.Controllers.Models.Entrada;
using Ecohub.Models;
using Ecohub.Repository.Entidades;
using Ecohub.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Ecohub.Controllers
{
    [ApiController]
    [Route("api/v1/usuario/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentException();
        }

        [HttpPost]
        public IActionResult Add(UsuarioViewModel user)
        {
          
            var userAdd = new UsuarioEntidade(user.Nome, user.CPF, user.DataNascimento, user.Email, user.Senha);
            _usuarioRepository.Add(userAdd);
            return Ok();
        }

        [HttpGet]
        [Route("/BuscarTodos") ]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _usuarioRepository.GetAll();
            return Ok(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string userId)
        {
            var user = await _usuarioRepository.Get(userId);
            return Ok(user);
        }

        [HttpPut]
        public IActionResult EditUser(UsuarioViewModel user, string userId)
        {
            _usuarioRepository.Update(user, userId);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteUser(string userId) {

            _usuarioRepository.Delete(userId);
            return Ok();
            
        }



    }
}
