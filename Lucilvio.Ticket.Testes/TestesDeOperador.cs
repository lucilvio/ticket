using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Testes
{
    [TestClass]
    public class TestesDeOperador
    {
        [TestMethod]
        public void AbreChamadoEmNomeDoCliente()
        {
            var operador = new Operador();
            var novoChamado = operador.AbrirChamado(new Cliente(), new GeradorDeProtocolo(2019, 0), "Chamado de teste");

            Assert.IsNotNull(novoChamado);
        }

        [TestMethod]
        public void RespondeAoChamado()
        {
            var cliente = new Cliente();
            var novoChamado = cliente.AbrirChamado(new GeradorDeProtocolo(2019, 0), "Chamado de teste", new SemNotificacao());

            var operador = new Operador();
            operador.ResponderAoChamado(novoChamado, "Resposta de teste");
        }
    }
}
