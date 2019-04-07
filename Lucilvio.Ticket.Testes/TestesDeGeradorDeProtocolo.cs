using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lucilvio.Ticket.Testes
{
    [TestClass]
    public class TestesDeGeradorDeProtocolo
    {
        [TestMethod]
        public void GeraProtocoloIniciadoPorUmSequencialIncrementadoSeguidoDoAnoInformado()
        {
            var gerador = new Protocolo.Gerador(0);

            Assert.AreEqual(20191, gerador.NovoProtocolo());
        }

        [TestMethod]
        public void GeraProtocoloSequencial()
        {
            var gerador = new Protocolo.Gerador(0);

            Assert.AreEqual(20191, gerador.NovoProtocolo());
            Assert.AreEqual(20192, gerador.NovoProtocolo());
            Assert.AreEqual(20193, gerador.NovoProtocolo());
            Assert.AreEqual(20194, gerador.NovoProtocolo());
        }

        [TestMethod]
        public void GeraProtocoloSequencialAPartirDeUmProtocoloAnterior()
        {
            var gerador = new Protocolo.Gerador(20191);

            Assert.AreEqual(20192, gerador.NovoProtocolo());
            Assert.AreEqual(20193, gerador.NovoProtocolo());
        }

        [TestMethod]
        public void AoVirarOAnoIniciarNovamenteOSequencial()
        {
            var gerador = new Protocolo.Gerador(20185);

            Assert.AreEqual(20180, gerador.NovoProtocolo());
        }
    }
}
