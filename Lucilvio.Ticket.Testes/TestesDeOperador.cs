using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Clientes;
using Lucilvio.Ticket.Dominio.Operadores;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lucilvio.Ticket.Testes
{
    [TestClass]
    public class TestesDeOperador
    {
        [TestMethod]
        public void AbreChamadoEmNomeDoCliente()
        {
            var operador = new Operador("Teste", "teste@teste.com", "123456");
            var novoChamado = operador.AbrirChamado(new Cliente("Teste", "Teste", "123456"), new Protocolo.Gerador(0), "Chamado de teste");

            Assert.IsNotNull(novoChamado);
        }

        [TestMethod]
        public void RespondeAoChamado()
        {
            var cliente = new Cliente("Teste", "Teste", "123456");
            var novoChamado = cliente.AbrirChamado(new Protocolo.Gerador(0).NovoProtocolo(), "Chamado de teste");

            var operador = new Operador("Teste", "teste@teste.com", "123456");
            operador.ResponderAoChamado(novoChamado, "Resposta de teste");
        }
    }
}
