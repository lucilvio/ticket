using Lucilvio.Ticket.Buscas.ListarOperadores;
using Lucilvio.Ticket.Servicos.CadastrarOperador;
using Lucilvio.Ticket.Servicos.Comum;
using Lucilvio.Ticket.Web.Autorizacao;
using Lucilvio.Ticket.Web.Chamados;
using Lucilvio.Ticket.Web.Operadores.Cadastro;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lucilvio.Ticket.Web.Operadores
{
    [Route("Operadores"), Authorize(Policy = Politicas.OperadoresEAdministradores)]
    public class OperadoresController : Controller
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
            this._servicos.Enviar(new ComandoParaCadastrarOperador(operador.Nome, operador.Email, 
                new SenhasParaConferencia(operador.Senha, operador.ConfirmacaoDaSenha)));

            TempData.Add("MensagemDeSucesso", "Operador cadastrado com sucesso");

            return RedirectToAction(nameof(Lista));
        }
    }
}
