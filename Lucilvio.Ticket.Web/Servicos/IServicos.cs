using Lucilvio.Ticket.Buscas;
using Lucilvio.Ticket.Servicos;

namespace Lucilvio.Ticket.Web.Chamados
{
    public interface IServicos
    {
        void Enviar(IComando comando);
        dynamic EnviarQuery(IQuery query); 
    }
}