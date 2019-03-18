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

        internal int AbrirChamado(string descricao)
        {
            var novoChamado = new Chamado(descricao);
            this._chamados.Add(novoChamado);

            return novoChamado.Protocolo;
        }
    }
}