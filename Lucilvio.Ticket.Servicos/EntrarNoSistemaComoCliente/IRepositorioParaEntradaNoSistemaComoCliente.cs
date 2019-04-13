using Lucilvio.Ticket.Dominio.Clientes;

namespace Lucilvio.Ticket.Servicos.EntrarNoSistemaComoCliente
{
    public interface IRepositorioParaEntradaNoSistemaComoCliente
    {
        Cliente PegarClientePeloLoginESenha(string login, string senha);
    }
}