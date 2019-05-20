using Lucilvio.Ticket.Dominio.Operadores;
using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Infra.RepositoriosEf.Comum;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaAtivacaoDoOperador
{
    public interface IAdaptadorDoRepositorioParaAtivacaoDoOperador : IAdaptador
    {
        Operador AdaptarOperadorParaEntidade(DadosDoOperador dados);
        DadosDoOperador AdaptarOperadorParaDados(Operador operador);
    }
}