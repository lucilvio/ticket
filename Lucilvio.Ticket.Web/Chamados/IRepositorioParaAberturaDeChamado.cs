using Lucilvio.Ticket.Testes;

namespace Lucilvio.Ticket.Web.Chamados
{
    public interface IRepositorioParaAberturaDeChamado
    {
        Cliente PegarClientePeloLogin(string login);
        int PegarProtocoloDoUltimoChamadoAberto();
        void AbrirChamado(Chamado chamado);
    }
}