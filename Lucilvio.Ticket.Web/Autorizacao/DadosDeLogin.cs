using System.Linq;
using System.Security.Claims;

namespace Lucilvio.Ticket.Web.Autorizacao
{
    public static class DadosDeLogin
    {
        public static string Login(this ClaimsPrincipal principal)
        {
            var claim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return claim != null ? principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value : "";
        }
    }
}
