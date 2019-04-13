using Lucilvio.Ticket.Buscas.ListarClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.ListarClientes
{
    public class ListarClientes : IListarClientes
    {
        private readonly Contexto _contexto;

        public ListarClientes(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public IReadOnlyList<ClienteDaLista> Executar(QueryParaListarClients query)
        {
            var clientes = this._contexto.Clientes.Skip(query.Pagina * query.RegistrosPorPagina)
                .Take(query.RegistrosPorPagina).ToList();

            return clientes.Select(c => new ClienteDaLista(c.Nome, c.Email, c.DataDoCadastro, c.Contatos)).ToList();
        }
    }
}
