using Lucilvio.Ticket.Dominio.Chamados;

namespace Lucilvio.Ticket.Servicos.AbrirChamado
{
    public interface IGeradorDeProtocolo
    {
        int Gerar(int ultimoProtocoloDeChamadoCriado);
    }
}