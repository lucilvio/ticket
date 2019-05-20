using Lucilvio.Ticket.Dominio.Clientes;

namespace Lucilvio.Ticket.Servicos.AbrirChamado
{
    public interface IRepositorioParaAberturaDeChamado : IRepositorio
    {
        Cliente PegarClientePeloLogin(string login);
        int PegarProtocoloDoUltimoChamadoAberto();
        void Persistir();
    }
}