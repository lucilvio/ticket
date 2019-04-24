using System.Threading.Tasks;

namespace Lucilvio.Ticket.Servicos
{
    public interface IServicoAsync<TComando> where TComando : IComando
    {
        Task Executar(TComando comando);
    }
}