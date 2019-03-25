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
        private readonly IBuscaDeChamados _buscaDeChamados;

        public ChamadosController(IRepositorioDeClientes repositorioDeClientes, IRepositorioDeChamados repositorioDeChamados, 
            IAdaptadorDeCliente adaptadorDeCliente, IBuscaDeChamados buscaDeChamados)
        {
            this._repositorioDeClientes = repositorioDeClientes;
            this._repositorioDeChamados = repositorioDeChamados;
            this._adaptadorDeCliente = adaptadorDeCliente;
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
            var abrirChamado = new AbrirChamado(this._repositorioDeClientes, this._repositorioDeChamados, this._adaptadorDeCliente);
            abrirChamado.Executar(new ComandoDeAberturaDoChamado(chamado.Cliente, chamado.Descricao));

            return RedirectToAction(nameof(Lista));
        }
    }

    public class AbrirChamado
    {
        private readonly IRepositorioDeClientes _repositorioDeClientes;
        private readonly IRepositorioDeChamados  _repositorioDeChamados;
        private readonly IAdaptadorDeCliente _adaptadorDeCliente;

        public AbrirChamado(IRepositorioDeClientes repositorioDeClientes, IRepositorioDeChamados repositorioDeChamados, IAdaptadorDeCliente adaptadorDeCliente)
        {
            this._repositorioDeClientes = repositorioDeClientes;
            this._repositorioDeChamados = repositorioDeChamados;
            this._adaptadorDeCliente = adaptadorDeCliente;
        }

        public void Executar(ComandoDeAberturaDoChamado comando)
        {
            var cliente = this._adaptadorDeCliente.Entidade(this._repositorioDeClientes.BuscarPeloLogin("login"));
            var ultimoProtocoloDeChamadoCriado = this._repositorioDeChamados.PegarUltimoProtocolo();

            var geradorDeProtocolo = new GeradorDeProtocolo(DateTime.Now.Year, ultimoProtocoloDeChamadoCriado);

            var novoChamado = cliente.AbrirChamado(geradorDeProtocolo, comando.Descricao, new SemNotificacao());

            this._repositorioDeChamados.Adicionar(novoChamado);
        }
    }

    public class ComandoDeAberturaDoChamado
    {
        public ComandoDeAberturaDoChamado(string cliente, string descricao)
        {
            this.Cliente = cliente;
            this.Descricao = descricao;
        }

        public string Cliente { get; }
        public string Descricao { get; }
    }
}
