using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Infra.GeradorDeProtocolo;
using Lucilvio.Ticket.Servicos.AbrirChamado;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lucilvio.Ticket.Testes
{
    [TestClass]
    public class TestesDeGeradorDeProtocolo
    {
        private IGeradorDeProtocolo _geradorDeProtocolo;

        [TestInitialize]
        public void Iniciar()
        {
            this._geradorDeProtocolo = new GeradorDeProtocolo();
        }

        [TestMethod]
        public void GeraProtocoloIniciadoPorUmSequencialIncrementadoSeguidoDoAnoInformado()
        {
            var protocolo = this._geradorDeProtocolo.Gerar(0);

            Assert.AreEqual(20191, protocolo);
        }

        [TestMethod]
        public void GeraProtocoloSequencial()
        {
            var protocolo = this._geradorDeProtocolo.Gerar(0);
            Assert.AreEqual(20191, protocolo);

            protocolo = this._geradorDeProtocolo.Gerar(protocolo);
            Assert.AreEqual(20192, protocolo);

            protocolo = this._geradorDeProtocolo.Gerar(protocolo);
            Assert.AreEqual(20193, protocolo);

            protocolo = this._geradorDeProtocolo.Gerar(protocolo);
            Assert.AreEqual(20194, protocolo);
        }

        [TestMethod]
        public void GeraProtocoloSequencialAPartirDeUmProtocoloAnterior()
        {
            var protocolo = this._geradorDeProtocolo.Gerar(20191);

            Assert.AreEqual(20192, protocolo);

            protocolo = this._geradorDeProtocolo.Gerar(protocolo);

            Assert.AreEqual(20193, protocolo);
        }

        [TestMethod]
        public void AoVirarOAnoIniciarNovamenteOSequencial()
        {
            var protocolo = this._geradorDeProtocolo.Gerar(20185);

            Assert.AreEqual(20191, protocolo);
        }
    }
}
