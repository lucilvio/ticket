using System;

namespace Lucilvio.Ticket.Testes
{
    internal class Operador
    {
        public Operador()
        {
        }

        internal Chamado AbrirChamado(Cliente cliente, GeradorDeProtocolo geradorDeProtocolo, string descricao)
        {
            return new Chamado(cliente, geradorDeProtocolo, descricao);
        }
    }
}