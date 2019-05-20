using System.Linq;
using System.Collections.Generic;
using Lucilvio.Ticket.Buscas.ListarOperadores;
using Dapper;

namespace Lucilvio.Ticket.Infra.BuscasComDapper.ListarOperadores
{
    public class ListarOperadores : IListarOperadores
    {
        private readonly Contexto _contexto;

        public ListarOperadores(Contexto contexto)
        {
            _contexto = contexto;
        }

        public IReadOnlyList<OperadorDaLista> Executar(QueryParaListarOperadores query)
        {
            using (var conexao = this._contexto.Conexao)
            {
                return conexao.Query<OperadorDaLista>(@"select Id, Nome, Email, DataDoCadastro, Ativo from Operadores
                    order by Id offset @pagina * @registrosPorPagina rows fetch next @registrosPorPagina rows only", query).ToList();
            }
        }
    }
}
