namespace Lucilvio.Ticket.Buscas.PegarChamadoPorId
{
    public class QueryParaPegarChamadoPorId : IQuery
    {
        public QueryParaPegarChamadoPorId(int id)
        {
            this.Id = id;
        }

        public int Id { get; }
    }
}