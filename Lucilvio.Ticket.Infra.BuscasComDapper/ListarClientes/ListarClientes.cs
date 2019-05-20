using Dapper;
using System.Linq;
using System.Collections.Generic;
using Lucilvio.Ticket.Buscas.ListarClientes;

namespace Lucilvio.Ticket.Infra.BuscasComDapper.ListarClientes
{
    public class ListarClientes : IListarClientes
    {
        private readonly Contexto _contexto;

        public ListarClientes(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public IReadOnlyList<ClienteDaLista> Executar(QueryParaListarClientes query)
        {
            using(var conexao = this._contexto.Conexao)
            {
                return conexao.Query<ClienteDaLista>(@"select Id, Nome, Email, DataDoCadastro from Clientes 
                    order by Id offset @pagina * @registrosPorPagina rows fetch next @registrosPorPagina rows only", query).ToList();
            }
        }
    }
}
