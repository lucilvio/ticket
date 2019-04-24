namespace Lucilvio.Ticket.Servicos
{
    public interface IServico<TComando> where TComando : IComando
    {
        void Executar(TComando comando);
    }
}