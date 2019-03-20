using System;

namespace Lucilvio.Ticket.Testes
{
    internal class Resposta
    {
        private Operador operador;
        private DateTime now;
        private string resposta;

        public Resposta(Operador operador, DateTime now, string resposta)
        {
            this.operador = operador;
            this.now = now;
            this.resposta = resposta;
        }
    }
}