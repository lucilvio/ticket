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
            var novoChamado = operador.AbrirChamado(new Cliente("Teste", "Teste"), new Protocolo.Gerador(0), "Chamado de teste");

            Assert.IsNotNull(novoChamado);
        }

        [TestMethod]
        public void RespondeAoChamado()
        {
            var cliente = new Cliente("Teste", "Teste");
            var novoChamado = cliente.AbrirChamado(new Protocolo.Gerador(0).NovoProtocolo(), "Chamado de teste", new SemNotificacao());

            var operador = new Operador();
            operador.ResponderAoChamado(novoChamado, "Resposta de teste");
        }
    }
}
