using Microsoft.AspNetCore.Mvc;

namespace Lucilvio.Ticket.Web.Chamados
{
    [Route("Chamados")]
    public class ChamadosController : Controller
    {
        private readonly IServicos _servicos;
        private readonly IBuscaDeChamados _buscaDeChamados;

        public ChamadosController(IServicos fabricaDeServicos, 
            IBuscaDeChamados buscaDeChamados)
        {
            this._servicos = fabricaDeServicos;            
            this._buscaDeChamados = buscaDeChamados;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Lista()
        {
            return View(this._buscaDeChamados.Executar());
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
