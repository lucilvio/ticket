namespace Lucilvio.Ticket.Buscas
{
    public abstract class QueryPaginaval : IQuery
    {
        public QueryPaginaval(int pagina, int registroPorPagina)
        {
            this.Pagina = pagina;
            this.RegistrosPorPagina = registroPorPagina;
        }

        public int Pagina { get; protected set; }
        public int RegistrosPorPagina { get; protected set; }
    }
}
