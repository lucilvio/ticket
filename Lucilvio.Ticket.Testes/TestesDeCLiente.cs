using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lucilvio.Ticket.Testes
{
    [TestClass]
    public class TestesDeCLiente
    {
        [TestMethod]
        public void ClienteRecebeProtocoloAoAbrirChamado()
        {
            var cliente = new Cliente();    
            var protocolo = cliente.AbrirChamado("Chamado de teste");

            Assert.IsTrue(protocolo > 0);
        }
    }
}
