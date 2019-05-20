using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Operadores;
using Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaInativacaoDoOperador;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public class AdaptadorDoRepositorioParaInativacaoDoOperador : IAdaptadorDoRepositorioParaInativacaoDoOperador
    {
        public Operador AdaptarOperadorParaEntidade(DadosDoOperador operador) => operador.ParaEntidade();
    }
}
