using Ecohub.Infra.Context;
using Ecohub.Infra.Repository.Interfaces;
using Ecohub.Models;
using Ecohub.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Ecohub.Infra.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly AppDbContext _context = new AppDbContext();
        public void Add(UsuarioModel user)
        {
            _context.Usuarios.Add(user);
            _context.SaveChanges();
        }

        public async Task<UsuarioModel> Get(string userId)
        {
            return await _context.Usuarios.FindAsync(userId);
        }

        public async Task<List<UsuarioModel>> GetAll()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public void Update(UsuarioViewModel user, string userId)
        {
            UsuarioModel userEdit = new UsuarioModel(
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


    }
}
