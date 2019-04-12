using Lucilvio.Ticket.Buscas.ListarOperadores;
using Lucilvio.Ticket.Dominio;
using Lucilvio.Ticket.Servicos.CadastrarOperador;
using Lucilvio.Ticket.Web.Chamados;
using Lucilvio.Ticket.Web.Operadores.Cadastro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lucilvio.Ticket.Web.Operadores
{
    [Route("Operadores")]
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
            try
            {
                this._servicos.Enviar(new ComandoParaCadastrarOperador(operador.Nome, operador.Email, operador.Senha, operador.ConfirmacaoDaSenha));
                TempData.Add("MensagemDeSucesso", "Operador cadastrado com sucesso");
            }
            catch (ExcecaoDeNegocio ex)
            {
                TempData.Clear();
                TempData.Add("MensagemDeErro", System.Text.RegularExpressions.Regex.Replace(ex.GetType().Name, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim());

                return RedirectToAction(nameof(Cadastro));
            }

            return RedirectToAction(nameof(Lista));
        }
    }
}
