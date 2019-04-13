using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Lucilvio.Ticket.Dominio.Usuarios;
using Lucilvio.Ticket.Servicos.EntrarNoSistema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Lucilvio.Ticket.Servicos.Comum;

namespace Lucilvio.Ticket.Infra.SegurancaPorCookie
{
    public class ServicoDeAutenticacaoViaCookie : IServicoDeAutenticacao
    {
        private readonly HttpContext _contextoWeb;

        public ServicoDeAutenticacaoViaCookie(HttpContext contextoWeb)
        {
            this._contextoWeb = contextoWeb;
        }

        public async Task AutenticarUsuario(Usuario usuario)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario.Login)
            };

            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "login"));
            await this._contextoWeb.SignInAsync(principal);
        }

        public async Task RevogarAutenticacao()
        {
            await this._contextoWeb.SignOutAsync();
        }
    }
}
