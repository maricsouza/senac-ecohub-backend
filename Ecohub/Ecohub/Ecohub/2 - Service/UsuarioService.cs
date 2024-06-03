using Ecohub._1___Controllers.Models.Entrada;
using Ecohub._2___Service;
using Ecohub.Controllers.Models.Entrada;
using Ecohub.Repository.Entidades;
using Ecohub.Repository.Interfaces;
using Ecohub.Service.Interfaces;
using SecureIdentity.Password;


namespace Ecohub.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly TokenService _tokenService = new TokenService();

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentException();
        }

        private bool _isMaiorDeIdade(DateTime data)
        {
            return true;
        }

        public void Adicionar(UsuarioViewModel user)
        {

            if(string.IsNullOrEmpty(user.Nome))
            {
                throw new Exception("O nome do usuário é obrigatório");
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                throw new Exception("O e-mail é obrigatório");
            }

            if(string.IsNullOrEmpty(user.CPF))
            {
                throw new Exception("O CPF é obrigatório");
            }

            if(string.IsNullOrEmpty(user.Senha))
            {
                throw new Exception("A senha é obrigatória");
            }

            if(!_isMaiorDeIdade(user.DataNascimento))
            {
                throw new Exception("O usuário precisa ser maior de idade");
            }

            var userAdd = new UsuarioEntidade(
                user.Nome, 
                user.CPF, 
                user.DataNascimento, 
                user.Email,
                PasswordHasher.Hash(user.Senha));

            _usuarioRepository.Add(userAdd);
        }

        public void Atualizar(UsuarioViewModel user, string userId)
        {
            _usuarioRepository.Update(user, userId);
        }

        public Task<UsuarioEntidade> Buscar(string userId)
        {
           var user =  _usuarioRepository.Get(userId);
           return user;
        }

        public Task<List<UsuarioEntidade>> BuscarTodos()
        {
            var users =  _usuarioRepository.GetAll();
            return users;
        }

        public void Deletar(string userId)
        {
            _usuarioRepository.Delete(userId);
        }

        public async Task<string> Login(LoginViewModel login)
        {
           
            var user = await _usuarioRepository.Login(login);


            if (PasswordHasher.Verify(user.Senha, login.senha))
                return _tokenService.GenerateToken(user);
          

                return "";

        }
    }
}
