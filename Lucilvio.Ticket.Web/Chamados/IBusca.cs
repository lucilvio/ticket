namespace Lucilvio.Ticket.Web.Chamados
{
    public interface IBusca<TRetorno, TQuery>
    {
        TRetorno Executar(TQuery query);
    }
}