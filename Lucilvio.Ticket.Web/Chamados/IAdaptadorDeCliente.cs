using Lucilvio.Ticket.Testes;

namespace Lucilvio.Ticket.Web.Chamados
{
    public interface IAdaptadorDeCliente
    {
        Cliente Entidade(DadosDoCliente dados);
    }
}