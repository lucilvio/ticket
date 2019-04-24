using Lucilvio.Ticket.Buscas;
using Lucilvio.Ticket.Servicos;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Web.Chamados
{
    public interface IServicos
    {
        void Enviar(IComando comando);
        Task EnviarAsync(IComando comando);
        dynamic EnviarQuery(IQuery query); 
    }
}