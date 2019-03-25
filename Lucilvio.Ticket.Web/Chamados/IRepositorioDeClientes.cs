using System.Linq;
using System.Collections.Generic;

namespace Lucilvio.Ticket.Web.Chamados
{
    public interface IRepositorioDeClientes
    {
        DadosDoCliente BuscarPeloLogin(string login);
    }

    public class RepositorioDeClientesEmMemoria : IRepositorioDeClientes
    {
        private IContexto _contexto;

        public RepositorioDeClientesEmMemoria(IContexto contexto)
        {
            this._contexto = contexto;
        }

        public DadosDoCliente BuscarPeloLogin(string login)
        {
            return this._contexto.Clientes.FirstOrDefault(c => c.Login == login);
        }
    }
}