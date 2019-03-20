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
        private static IList<DadosDoCliente> _clientes;

        public RepositorioDeClientesEmMemoria()
        {
            _clientes = new List<DadosDoCliente>();
        }

        public DadosDoCliente BuscarPeloLogin(string login)
        {
            return _clientes.FirstOrDefault(c => c.Login == login);
        }
    }
}