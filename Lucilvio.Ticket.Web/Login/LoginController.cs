using Lucilvio.Ticket.Dominio;
using Lucilvio.Ticket.Servicos.EntrarNoSistema;
using Lucilvio.Ticket.Web.Chamados;
using Lucilvio.Ticket.Web.Login.Entrar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Web.Login
{
    [Route("Login"), AllowAnonymous]
    public class LoginController : TicketController
    {
        private readonly IServicos _servicos;

        public LoginController(IServicos servicos)
        {
            this._servicos = servicos;
        }

        [HttpGet, Route("Entrar")]
        public ActionResult Entrar()
        {
            return View();
        }

        [HttpPost, Route("Entrar")]
        public async Task<IActionResult> Entrar(DadosDoLogin dados)
        {
            try
            {
                await this._servicos.EnviarAsync(new ComandoParaEntrarNoSistema(dados.Usuario, dados.Senha));
                return RedirectToAction("Index", "Home");
            }
            catch(ExcecaoDeNegocio ex)
            {
                return RedirecionarComErro("Entrar", ex.GetType().Name.ToString());
            }
        }
    }
}
