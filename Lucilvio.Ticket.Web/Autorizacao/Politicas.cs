using Lucilvio.Ticket.Dominio.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Web.Autorizacao
{
    public class Politicas
    {
        public const string ApenasAdministradores = "ApenasAdministradores";
        public const string OperadoresEAdministradores = "OperadoresEAdministradores";
    }
}
