using System;
using Lucilvio.Ticket.Testes;
using Microsoft.AspNetCore.Mvc;

namespace Lucilvio.Ticket.Web.Chamados
{
    [Route("Chamados")]
    public class ChamadosController : Controller
    {
        private readonly IRepositorioDeClientes _repositorioDeClientes;
        private readonly IRepositorioDeChamados _repositorioDeChamados;
        private readonly IAdaptadorDeCliente _adaptadorDeCliente;

        public ChamadosController(IRepositorioDeClientes repositorioDeClientes, IRepositorioDeChamados repositorioDeChamados, IAdaptadorDeCliente adaptadorDeCliente)
        {
            this._repositorioDeClientes = repositorioDeClientes;
            this._repositorioDeChamados = repositorioDeChamados;
            this._adaptadorDeCliente = adaptadorDeCliente;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Lista()
        {
            var chamados = this._repositorioDeChamados.Listar();
            return View(chamados);
        }

        [HttpGet]
        [Route("Novo")]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [Route("Novo")]
        public IActionResult Novo(NovoChamado chamado)
        {
            var cliente = this._adaptadorDeCliente.Entidade(this._repositorioDeClientes.BuscarPeloLogin("login"));
            var ultimoProtocoloDeChamadoCriado = this._repositorioDeChamados.PegarUltimoProtocolo();

            var novoChamado = cliente.AbrirChamado(new GeradorDeProtocolo(DateTime.Now.Year, ultimoProtocoloDeChamadoCriado), chamado.Descricao, new SemNotificacao());

            this._repositorioDeChamados.Adicionar(novoChamado);

            return RedirectToAction(nameof(Lista));
        }
    }
}
