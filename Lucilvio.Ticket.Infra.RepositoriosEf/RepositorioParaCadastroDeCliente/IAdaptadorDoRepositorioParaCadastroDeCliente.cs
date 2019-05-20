using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Clientes;
using Lucilvio.Ticket.Infra.RepositoriosEf.Comum;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaCadastroDeCliente
{
    public interface IAdaptadorDoRepositorioParaCadastroDeCliente : IAdaptador
    {
        DadosDoCliente AdaptarClienteParaDados(Cliente novoCliente);
    }
}