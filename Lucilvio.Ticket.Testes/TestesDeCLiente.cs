using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lucilvio.Ticket.Testes
{
    [TestClass]
    public class TestesDeCliente
    {
        private Cliente _cliente;
        private GeradorDeProtocolo _geradorDeProtocolo;
        private string _descricaoDoChamado;

        [TestInitialize]
        public void Iniciar()
        {
            this._cliente = new Cliente();
            this._geradorDeProtocolo = new GeradorDeProtocolo(2019, 0);
            this._descricaoDoChamado = "Chamado de teste";
        }

        [TestMethod]
        public void ClienteAbreChamadoComADescricaoDoProblema()
        {
            var novoChamado = this._cliente.AbrirChamado(this._geradorDeProtocolo, this._descricaoDoChamado, new SemNotificacao());

            Assert.IsTrue(novoChamado != null);
        }

        [TestMethod]
        [ExpectedException(typeof(FaltaDescricaoDoProblema))]
        public void NaoAbreChamadoSemADescricaoDoProblema()
        {
            var novoChamado = this._cliente.AbrirChamado(this._geradorDeProtocolo, string.Empty, new SemNotificacao());
        }

        [TestMethod]
        public void ClienteRecebeProtocoloAoAbrirChamado()
        {
            var novoChamado = this._cliente.AbrirChamado(this._geradorDeProtocolo, this._descricaoDoChamado, new SemNotificacao());

            Assert.IsTrue(novoChamado != null);
            Assert.IsTrue(!string.IsNullOrEmpty(novoChamado.Protocolo));
        }

        [TestMethod]
        public void ClienteEhNotificadoViaEmailQuandoOChamadoEhAberto()
        {
            var notificacaoDeVerificacao = new NotificacaoDeVerificacao();
            this._cliente.AbrirChamado(this._geradorDeProtocolo, this._descricaoDoChamado, notificacaoDeVerificacao);

            Assert.IsTrue(notificacaoDeVerificacao.EnviouNotificacao);
        }

        [TestMethod]
        public void GeraNumeroUnicoDeProtocoloParaCadaChamadoAberto()
        {
            var chamado = this._cliente.AbrirChamado(this._geradorDeProtocolo, this._descricaoDoChamado, new SemNotificacao());
            var outroChamado = this._cliente.AbrirChamado(this._geradorDeProtocolo, this._descricaoDoChamado, new SemNotificacao());

            Assert.IsTrue(chamado.Protocolo == "12019");
            Assert.IsTrue(outroChamado.Protocolo == "22019");
        }
    }

    internal class ProtocoloJaUtilizado : Exception
    {
        public ProtocoloJaUtilizado()
        {
        }
    }

    internal class NotificacaoDeVerificacao : IServicoDeNotificacao
    {
        public bool EnviouNotificacao { get; set; }

        public void Notificar(Notificacao notificacao)
        {
            this.EnviouNotificacao = true;
        }
    }

    internal class SemNotificacao : IServicoDeNotificacao
    {
        public void Notificar(Notificacao notificacao)
        {
        }
    }
}
