using Ecohub.Repository.Entidades;
using System.Security.Claims;

namespace Ecohub
{
    public static class RoleClaimExtention
    {
       public static IEnumerable<Claim> GetClaims(this UsuarioEntidade user)
        {
            var result = new List<Claim>
            {
                new(ClaimTypes.Email, user.Email)
            };
            return result;
        }
    }
}
