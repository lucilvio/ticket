namespace Lucilvio.Ticket.Buscas
{
    public interface IBusca<TRetorno, TQuery> where TQuery : IQuery
    {
        TRetorno Executar(TQuery query);
    }
}