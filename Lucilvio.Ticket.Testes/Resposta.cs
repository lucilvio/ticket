using System;

namespace Lucilvio.Ticket.Testes
{
    internal class Resposta
    {
        private Operador _operador;
        private DateTime _data;
        private string _resposta;

        private readonly Chamado _chamado;

        public Resposta(Chamado chamado, Operador operador, string resposta)
        {
            this._chamado = chamado;
            this._operador = operador;
            this._data = DateTime.Now;
            this._resposta = resposta;
        }
    }
}