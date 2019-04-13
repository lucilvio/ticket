using Lucilvio.Ticket.Servicos.SairDoSistema;
using Lucilvio.Ticket.Web.Chamados;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Web.Sair
{
    [Route("Sair")]
    public class SairController : Controller
    {
        private readonly IServicos _servicos;

        public SairController(IServicos servicos)
        {
            this._servicos = servicos;
        }

        [Route("")]
        public async Task<IActionResult> Sair()
        {
            await this._servicos.Enviar(new ComandoParaSairDoSistema());
            return RedirectToAction("Index", "Home");
        }    
    }
}
