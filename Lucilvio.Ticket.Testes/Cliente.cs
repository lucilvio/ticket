using System;
using System.Collections.Generic;

namespace Lucilvio.Ticket.Testes
{
    internal class Cliente
    {
        private IList<Chamado> _chamados;

        public Cliente()
        {
            this._chamados = new List<Chamado>();
        }

        internal void AbrirChamado(string descricao)
        {
            this._chamados.Add(new Chamado(descricao));
        }
    }
}