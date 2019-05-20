using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Clientes;
using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Infra.RepositoriosEf.Comum;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaAberturaDeChamado
{
    public interface IAdaptadorDoRepositorioParaAberturaDeChamado : IAdaptador
    {
        Cliente AdaptarClienteParaEntidade(DadosDoCliente cliente);
        DadosDoChamado AdaptarChamadoParaDados(Chamado chamado);
    }
}