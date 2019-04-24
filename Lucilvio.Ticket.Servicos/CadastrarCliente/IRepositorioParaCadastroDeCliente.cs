using Lucilvio.Ticket.Dominio.Clientes;

namespace Lucilvio.Ticket.Servicos.CadastrarCliente
{
    public interface IRepositorioParaCadastroDeCliente : IRepositorio
    {
        void AdicionarCliente(Cliente novoCliente);
        void Persistir();
    }
}