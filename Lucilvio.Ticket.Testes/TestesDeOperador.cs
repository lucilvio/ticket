using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lucilvio.Ticket.Testes
{
    [TestClass]
    public class TestesDeOperador
    {
        [TestMethod]
        public void AbreChamadoEmNomeDoCliente()
        {
            var operador = new Operador();
            var novoChamado = operador.AbrirChamado(new Cliente("Teste"), new GeradorDeProtocolo(2019, 0), "Chamado de teste");

            Assert.IsNotNull(novoChamado);
        }

        [TestMethod]
        public void RespondeAoChamado()
        {
            var cliente = new Cliente("Teste");
            var novoChamado = cliente.AbrirChamado(new GeradorDeProtocolo(2019, 0), "Chamado de teste", new SemNotificacao());

            var operador = new Operador();
            operador.ResponderAoChamado(novoChamado, "Resposta de teste");
        }
    }
}
