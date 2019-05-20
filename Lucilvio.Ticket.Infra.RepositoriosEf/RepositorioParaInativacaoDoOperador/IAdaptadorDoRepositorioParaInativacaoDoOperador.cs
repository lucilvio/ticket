using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Operadores;
using Lucilvio.Ticket.Infra.RepositoriosEf.Comum;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaInativacaoDoOperador
{
    public interface IAdaptadorDoRepositorioParaInativacaoDoOperador : IAdaptador
    {
        Operador AdaptarOperadorParaEntidade(DadosDoOperador dadosDoOperador);
        DadosDoOperador AdaptarOperadorParaDados(Operador operador);
    }
}