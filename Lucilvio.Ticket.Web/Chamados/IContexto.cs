using System.Collections.Generic;

namespace Lucilvio.Ticket.Web.Chamados
{
    public interface IContexto
    {
        IList<DadosDoChamado> Chamados { get; }
        IList<DadosDoCliente> Clientes { get; }
    }

    public class ContextoEmMemoria : IContexto
    {
        private IList<DadosDoChamado> _chamados;
        private IList<DadosDoCliente> _clientes;

        public ContextoEmMemoria()
        {
            this._chamados = new List<DadosDoChamado>();
            this._clientes = new List<DadosDoCliente>();
        }

        public IList<DadosDoChamado> Chamados => this._chamados;

        public IList<DadosDoCliente> Clientes => this._clientes;
    }
}
