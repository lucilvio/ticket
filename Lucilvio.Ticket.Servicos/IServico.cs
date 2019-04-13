using System.Threading.Tasks;

namespace Lucilvio.Ticket.Servicos
{
    public interface IServico<TComando> where TComando : IComando
    {
        Task Executar(TComando comando);
    }
}