using Ecohub.Models;
using Ecohub.Repository;
using Ecohub.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Ecohub.Controllers
{
    [ApiController]
    [Route("api/v1/usuario")]
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
          
            var userAdd = new UsuarioModel(user.Nome, user.CPF, user.DataNascimento, user.Email, user.Senha);
            _usuarioRepository.Add(userAdd);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _usuarioRepository.GetAll();
            return Ok(users);
        }

    }
}
