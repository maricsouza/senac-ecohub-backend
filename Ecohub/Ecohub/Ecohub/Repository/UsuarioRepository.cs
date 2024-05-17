using Ecohub.Context;
using Ecohub.Models;

namespace Ecohub.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
     
        private readonly AppDbContext _context = new AppDbContext();
        public void Add(Usuario user)
        {
            _context.Usuarios.Add(user);
            _context.SaveChanges();
        }

        public List<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
