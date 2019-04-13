using Lucilvio.Ticket.Dominio.Usuarios;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lucilvio.Ticket.Dominio.Usuarios.Usuario;

namespace Lucilvio.Ticket.Web.Autorizacao
{
    public static class ConfiguracaoDePoliticas
    {
        public static void Configurar(AuthorizationOptions opcoes)
        {
            opcoes.AddPolicy(Politicas.ApenasAdministradores, p => p.RequireRole(PerfilDoUsuario.Administrador.ToString()));
            opcoes.AddPolicy(Politicas.OperadoresEAdministradores, p => p.RequireRole(PerfilDoUsuario.Administrador.ToString(), PerfilDoUsuario.Operador.ToString()));
        }
    }
}
