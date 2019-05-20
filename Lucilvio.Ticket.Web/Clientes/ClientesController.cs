using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Lucilvio.Ticket.Web.Chamados;
using Lucilvio.Ticket.Servicos.Comum;
using Lucilvio.Ticket.Web.Autorizacao;
using Microsoft.AspNetCore.Authorization;
using Lucilvio.Ticket.Buscas.ListarClientes;
using Lucilvio.Ticket.Web.Clientes.Cadastro;
using Lucilvio.Ticket.Servicos.CadastrarCliente;

namespace Lucilvio.Ticket.Web.Clientes
{
    [Route("Clientes"), Authorize(Policy = Politicas.OperadoresEAdministradores)]
    public class ClientesController : Controller
    {
        private readonly IServicos _servicos;

        public ClientesController(IServicos servicos)
        {
            this._servicos = servicos;
        }

        [HttpGet, Route("")]
        public IActionResult Lista()
        {
            var clientes = this._servicos.EnviarQuery(new QueryParaListarClientes(0, 10));
            return View(clientes);
        }

        [HttpGet, Route("Cadastro")]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost, Route("Cadastrar")]
        public IActionResult Cadastrar(DadosDoNovoCliente dados)
        {
            this._servicos.Enviar(new ComandoParaCadastrarCliente(dados.Nome, dados.Email, new SenhasParaConferencia(dados.Senha, dados.ConfirmacaoDaSenha),
                dados.Contatos.Select(c => new ComandoParaCadastrarCliente.Contato(c.Valor, c.Tipo))));

            return RedirectToAction(nameof(Lista));
        }
    }
}