using System.Security.Principal;
using Lucilvio.Ticket.Dominio.Usuarios;

namespace Lucilvio.Ticket.Web.Autorizacao
{
    public static class Autorizacao
    {
        public static bool EhOperador(this IPrincipal principal)
        {
            if (principal.IsInRole(Usuario.PerfilDoUsuario.Operador.ToString()))
                return true;

            return false;
        }

        public static bool EhCliente(this IPrincipal principal)
        {
            if (principal.IsInRole(Usuario.PerfilDoUsuario.Cliente.ToString()))
                return true;

            return false;
        }

        public static bool EhAdministrador(this IPrincipal principal)
        {
            if (principal.IsInRole(Usuario.PerfilDoUsuario.Administrador.ToString()))
                return true;

            return false;
        }
    }
}
