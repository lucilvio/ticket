using Microsoft.AspNetCore.Mvc;

namespace Lucilvio.Ticket.Web.Chamados
{
    [Route("Chamados")]
    public class ChamadosController : Controller
    {
        private readonly IServicos _servicos;

        public ChamadosController(IServicos servicos)
        {
            this._servicos = servicos;            
        }

        [HttpGet]
        [Route("")]
        public IActionResult Lista()
        {
            return View(this._servicos.EnviarQuery(new QueryParaListarChamados(0, 10)));
        }

        [HttpGet]
        [Route("Novo")]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [Route("Novo")]
        public IActionResult Novo(DadosDoNovoChamado chamado)
        {
            this._servicos.Enviar(new ComandoParaAbrirChamado(chamado.Cliente, chamado.Descricao));

            return RedirectToAction(nameof(Lista));
        }
    }
}
