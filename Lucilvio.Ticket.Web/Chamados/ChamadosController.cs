using Lucilvio.Ticket.Buscas.ListarChamados;
using Lucilvio.Ticket.Buscas.PegarChamadoPeloProtocolo;
using Lucilvio.Ticket.Servicos.AbrirChamado;
using Lucilvio.Ticket.Servicos.ResponderChamado;
using Lucilvio.Ticket.Web.Chamados.Novo;
using Lucilvio.Ticket.Web.Chamados.Responder;
using Microsoft.AspNetCore.Authorization;
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
        [Route("Cadastro")]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(DadosDoNovoChamado chamado)
        {
            this._servicos.Enviar(new ComandoParaAbrirChamado("teste", chamado.Descricao));

            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        [Route("Ver/{protocolo}")]
        public IActionResult Ver(int protocolo)
        {
            var chamado = this._servicos.EnviarQuery(new QueryParaPegarChamadoPorProtocolo(protocolo));
            return View(chamado);
        }

        [HttpPost]
        [Route("Responder")]
        public IActionResult Responder(DadosDaResposta resposta)
        {
            this._servicos.Enviar(new ComandoParaResponderChamado(resposta.Texto, int.Parse(resposta.Chamado), resposta.Operador));
            return RedirectToAction(nameof(Ver), new { protocolo = resposta.Chamado });
        }
    }
}
