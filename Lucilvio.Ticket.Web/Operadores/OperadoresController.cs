using Lucilvio.Ticket.Buscas.ListarOperadores;
using Lucilvio.Ticket.Dominio;
using Lucilvio.Ticket.Servicos.AtivarOperador;
using Lucilvio.Ticket.Servicos.CadastrarOperador;
using Lucilvio.Ticket.Servicos.Comum;
using Lucilvio.Ticket.Servicos.InativarOperador;
using Lucilvio.Ticket.Web.Autorizacao;
using Lucilvio.Ticket.Web.Chamados;
using Lucilvio.Ticket.Web.Operadores.Cadastro;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lucilvio.Ticket.Web.Operadores
{
    [Route("Operadores"), Authorize(Policy = Politicas.ApenasAdministradores)]
    public class OperadoresController : TicketController
    {
        private readonly IServicos _servicos;

        public OperadoresController(IServicos servicos)
        {
            this._servicos = servicos;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Lista()
        {
            var operadores = this._servicos.EnviarQuery(new QueryParaListarOperadores(0, 10));
            return View(operadores);
        }

        [HttpGet]
        [Route("Cadastro")]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(DadosDoNovoOperador operador)
        {
            try
            {
                this._servicos.Enviar(new ComandoParaCadastrarOperador(operador.Nome, operador.Email,
                    new SenhasParaConferencia(operador.Senha, operador.ConfirmacaoDaSenha)));
            }
            catch (ExcecaoDeNegocio e)
            {
                return RedirecionarComErro(nameof(Cadastro), e.GetType().Name);
            }

            return RedirecionarComSucesso(nameof(Lista), "Operador cadastrado com sucesso");
        }

        [HttpGet, Route("Inativar")]
        public IActionResult Inativar(int id)
        {
            this._servicos.Enviar(new ComandoParaInativarOperador(id));

            return RedirecionarComSucesso(nameof(Lista), "Operador inativado");
        }

        [HttpGet, Route("Ativar")]
        public IActionResult Ativar(int id)
        {
            this._servicos.Enviar(new ComandoParaAtivarOperador(id));

            return RedirecionarComSucesso(nameof(Lista), "Operador ativado");
        }
    }
}
