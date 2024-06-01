using Ecohub._1___Controllers.Models.Entrada;
using Ecohub.Controllers.Models.Entrada;
using Ecohub.Infra.Context;
using Ecohub.Repository.Entidades;
using Ecohub.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecohub.Repository.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly AppDbContext _context = new AppDbContext();
        public void Add(UsuarioEntidade user)
        {
            _context.Usuarios.Add(user);
            _context.SaveChanges();
        }

        public async Task<UsuarioEntidade> Get(string userId)
        {
            return await _context.Usuarios.FindAsync(userId);
        }

        public async Task<List<UsuarioEntidade>> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public void Update(UsuarioViewModel user, string userId)
        {
            UsuarioEntidade userEdit = new UsuarioEntidade(
                userId,
                user.Nome,
                user.CPF,
                user.DataNascimento,
                user.Email,
                user.Senha);
            _context.Usuarios.Update(userEdit);
            _context.SaveChanges();
        }

        public async void Delete(string userId)
        {
            var userDelte = await Get(userId);
            _context.Usuarios.Remove(userDelte);
            _context.SaveChanges();
        }

        public async Task<UsuarioEntidade> Login(LoginViewModel login)
        {

            var userLogin = await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == login.Email);

            return userLogin;

        }
    }
}
