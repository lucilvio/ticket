using System;
using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lucilvio.Ticket.Testes
{
    [TestClass]
    public class TestesDeCliente
    {
        private Cliente _cliente;
        private Protocolo.Gerador _geradorDeProtocolo;
        private string _descricaoDoChamado;

        [TestInitialize]
        public void Iniciar()
        {
            this._cliente = new Cliente("teste", "Teste", "123456");
            this._geradorDeProtocolo = new Protocolo.Gerador(0);
            this._descricaoDoChamado = "Chamado de teste";
        }

        [TestMethod]
        public void ClienteAbreChamadoComADescricaoDoProblema()
        {
            var novoChamado = this._cliente.AbrirChamado(this._geradorDeProtocolo.NovoProtocolo(), this._descricaoDoChamado);

            Assert.IsTrue(novoChamado != null);
        }

        [TestMethod]
        [ExpectedException(typeof(ChamadoNaoPodeSerAbertoSemDescricao))]
        public void NaoAbreChamadoSemADescricaoDoProblema()
        {
            var novoChamado = this._cliente.AbrirChamado(this._geradorDeProtocolo.NovoProtocolo(), string.Empty);
        }

        [TestMethod]
        public void ClienteRecebeProtocoloAoAbrirChamado()
        {
            var novoChamado = this._cliente.AbrirChamado(this._geradorDeProtocolo.NovoProtocolo(), this._descricaoDoChamado);

            Assert.IsTrue(novoChamado != null);
            Assert.IsTrue(novoChamado.Protocolo == 20191);
        }

        [TestMethod]
        public void GeraNumeroUnicoDeProtocoloParaCadaChamadoAberto()
        {
            var chamado = this._cliente.AbrirChamado(this._geradorDeProtocolo.NovoProtocolo(), this._descricaoDoChamado);
            var outroChamado = this._cliente.AbrirChamado(this._geradorDeProtocolo.NovoProtocolo(), this._descricaoDoChamado);
            var outroChamado2 = this._cliente.AbrirChamado(this._geradorDeProtocolo.NovoProtocolo(), this._descricaoDoChamado);

            Assert.IsTrue(chamado.Protocolo == 20191);
            Assert.IsTrue(outroChamado.Protocolo == 20192);
            Assert.IsTrue(outroChamado2.Protocolo == 20193);
        }
    }
}
