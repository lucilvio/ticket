namespace Lucilvio.Ticket.Web.Chamados
{
    public interface IServico<TComando> where TComando : IComando
    {
        void Executar(TComando comando);
    }
}