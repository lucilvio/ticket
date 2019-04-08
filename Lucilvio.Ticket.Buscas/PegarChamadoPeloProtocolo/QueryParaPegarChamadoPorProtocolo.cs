namespace Lucilvio.Ticket.Buscas.PegarChamadoPeloProtocolo
{
    public class QueryParaPegarChamadoPorProtocolo : IQuery
    {
        public QueryParaPegarChamadoPorProtocolo(int protocolo)
        {
            this.Protocolo = protocolo;
        }

        public int Protocolo { get; }
    }
}