using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Lucilvio.Ticket.Servicos.Comum.ServicosExternos.Autenticacao;

namespace Lucilvio.Ticket.Infra.SegurancaPorCookie
{
    public class ServicoDeAutenticacaoViaCookie : IServicoDeAutenticacao
    {
        private readonly HttpContext _contextoWeb;

        public ServicoDeAutenticacaoViaCookie(HttpContext contextoWeb)
        {
            this._contextoWeb = contextoWeb;
        }

        public async Task Autenticar(DadosDeAutenticacao dados)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, !string.IsNullOrEmpty(dados.Nome) ? dados.Nome : ""),
                new Claim(ClaimTypes.Email, !string.IsNullOrEmpty(dados.Email) ? dados.Email : ""),
                new Claim(ClaimTypes.Role, !string.IsNullOrEmpty(dados.Perfil) ? dados.Perfil : ""),
                new Claim(ClaimTypes.NameIdentifier, !string.IsNullOrEmpty(dados.Login) ? dados.Login : "")
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