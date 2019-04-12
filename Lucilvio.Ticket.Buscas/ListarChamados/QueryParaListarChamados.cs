using System.Collections.Generic;

namespace Lucilvio.Ticket.Buscas.ListarChamados
{
    public class QueryParaListarChamados : QueryPaginaval
    {
        public QueryParaListarChamados(int pagina, int registrosPorPagina) : base(pagina, registrosPorPagina)
        {
        }
    }
}