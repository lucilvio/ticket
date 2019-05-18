using System;
using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Clientes;
using Lucilvio.Ticket.Servicos.AbrirChamado;
using Lucilvio.Ticket.Infra.GeradorDeProtocolo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lucilvio.Ticket.Testes
{
    [TestClass]
    public class TestesDeCliente
    {
        private Cliente _cliente;
        private Protocolo _protocolo;
        private string _descricaoDoChamado;
        private IGeradorDeProtocolo _geradorDeProtocolo;

        [TestInitialize]
        public void Iniciar()
        {
            this._descricaoDoChamado = "Chamado de teste";
            this._geradorDeProtocolo = new GeradorDeProtocolo();
            this._cliente = new Cliente("teste", "Teste", "123456");

            this._protocolo = new Protocolo(this._geradorDeProtocolo.Gerar(0));
        }

        [TestMethod]
        public void ClienteAbreChamadoComADescricaoDoProblema()
        {
            var novoChamado = this._cliente.AbrirChamado(this._protocolo, this._descricaoDoChamado);

            Assert.IsTrue(novoChamado != null);
        }

        [TestMethod]
        [ExpectedException(typeof(ChamadoNaoPodeSerAbertoSemDescricao))]
        public void NaoAbreChamadoSemADescricaoDoProblema()
        {
            var novoChamado = this._cliente.AbrirChamado(this._protocolo, string.Empty);
        }

        [TestMethod]
        public void ClienteRecebeProtocoloAoAbrirChamado()
        {
            var novoChamado = this._cliente.AbrirChamado(this._protocolo, this._descricaoDoChamado);

            Assert.IsTrue(novoChamado != null);
            Assert.IsTrue(novoChamado.Protocolo == 20191);
        }

        [TestMethod]
        public void GeraNumeroUnicoDeProtocoloParaCadaChamadoAberto()
        {
            var ultimoProtocolo = this._geradorDeProtocolo.Gerar(0);
            var chamado = this._cliente.AbrirChamado(new Protocolo(ultimoProtocolo), this._descricaoDoChamado);

            ultimoProtocolo = this._geradorDeProtocolo.Gerar(ultimoProtocolo);

            var outroChamado = this._cliente.AbrirChamado(new Protocolo(ultimoProtocolo), this._descricaoDoChamado);

            ultimoProtocolo = this._geradorDeProtocolo.Gerar(ultimoProtocolo);

            var outroChamado2 = this._cliente.AbrirChamado(new Protocolo(ultimoProtocolo), this._descricaoDoChamado);

            Assert.IsTrue(chamado.Protocolo == 20191);
            Assert.IsTrue(outroChamado.Protocolo == 20192);
            Assert.IsTrue(outroChamado2.Protocolo == 20193);
        }
    }
}
