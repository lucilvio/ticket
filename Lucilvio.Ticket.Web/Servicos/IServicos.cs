using Lucilvio.Ticket.Buscas;
using Lucilvio.Ticket.Servicos;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Web.Chamados
{
    public interface IServicos
    {
        Task Enviar(IComando comando);
        dynamic EnviarQuery(IQuery query); 
    }
}