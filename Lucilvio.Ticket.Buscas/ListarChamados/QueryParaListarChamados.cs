using System.Collections.Generic;

namespace Lucilvio.Ticket.Buscas.ListarChamados
{
    public class QueryParaListarChamados : IQuery
    {
        public QueryParaListarChamados(int pagina, int registrosPorPagina)
        {
            this.Pagina = pagina;
            this.RegistrosPorPagina = registrosPorPagina;
        }

        public int Pagina { get; set; }
        public int RegistrosPorPagina { get; set; }
    }
}