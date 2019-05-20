using Microsoft.AspNetCore.Mvc;
using Lucilvio.Ticket.Web.Chamados.Novo;
using Lucilvio.Ticket.Buscas.ListarChamados;
using Lucilvio.Ticket.Servicos.AbrirChamado;
using Lucilvio.Ticket.Web.Chamados.Responder;
using Lucilvio.Ticket.Servicos.ResponderChamado;
using Lucilvio.Ticket.Dominio;
using Lucilvio.Ticket.Web.Autorizacao;
using Lucilvio.Ticket.Buscas.PegarChamadoPorId;

namespace Lucilvio.Ticket.Web.Chamados
{
    [Route("Chamados")]
    public class ChamadosController : TicketController
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
            try
            {
                this._servicos.Enviar(new ComandoParaAbrirChamado(User.Login(), chamado.Descricao));
                return RedirecionarComSucesso(nameof(Lista), "Chamado registrado com sucesso");
            }
            catch(ExcecaoDeNegocio ex)
            {
                return RedirecionarComErro(nameof(Cadastro), ex.GetType().Name);
            }
        }

        [HttpGet]
        [Route("Ver/{id}")]
        public IActionResult Ver(int id)
        {
            var chamado = this._servicos.EnviarQuery(new QueryParaPegarChamadoPorId(id));

            if (chamado == null)
                return RedirecionarComErro(nameof(Lista), "Chamado não encontrado");

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
