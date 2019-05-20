using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Operadores;
using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Infra.RepositoriosEf.Comum;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaResponderChamado
{
    public interface IAdaptadorDoRepositorioParaResponderChamado : IAdaptador
    {
        Chamado AdaptarChamadoParaEntidade(DadosDoChamado dadosDoChamado);
        Operador AdaptarOperadorParaEntidade(DadosDoOperador dadosDoOperador);
    }
}