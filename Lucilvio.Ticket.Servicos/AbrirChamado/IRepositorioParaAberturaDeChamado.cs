using Lucilvio.Ticket.Dominio;
using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Clientes;

namespace Lucilvio.Ticket.Servicos.AbrirChamado
{
    public interface IRepositorioParaAberturaDeChamado
    {
        Cliente PegarClientePeloLogin(string login);
        int PegarProtocoloDoUltimoChamadoAberto();
        void Persistir();
    }
}