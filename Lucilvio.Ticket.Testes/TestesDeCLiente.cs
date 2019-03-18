using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lucilvio.Ticket.Testes
{
    [TestClass]
    public class TestesDeCLiente
    {
        [TestMethod]
        public void ClienteAbreChamado()
        {
            var cliente = new Cliente();    
            cliente.AbrirChamado("Chamado de teste");
        }
    }
}
