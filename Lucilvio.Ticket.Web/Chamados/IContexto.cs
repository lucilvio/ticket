using Lucilvio.Ticket.Testes;
using System.Collections.Generic;

namespace Lucilvio.Ticket.Web.Chamados
{
    public interface IContexto
    {
        IList<Chamado> Chamados { get; }
        IList<Cliente> Clientes { get; }
    }

    public class ContextoEmMemoria : IContexto
    {
        private IList<Chamado> _chamados;
        private IList<Cliente> _clientes;

        public ContextoEmMemoria()
        {
            this._chamados = new List<Chamado>();
            this._clientes = new List<Cliente>() { new Cliente("login", "Teste") };
        }

        public IList<Chamado> Chamados => this._chamados;

        public IList<Cliente> Clientes => this._clientes;
    }
}
