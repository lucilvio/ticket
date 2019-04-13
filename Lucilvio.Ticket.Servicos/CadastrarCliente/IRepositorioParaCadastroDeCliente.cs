using Lucilvio.Ticket.Dominio.Clientes;

namespace Lucilvio.Ticket.Servicos.CadastrarCliente
{
    public interface IRepositorioParaCadastroDeCliente
    {
        void AdicionarCliente(Cliente novoCliente);
        void Persistir();
    }
}