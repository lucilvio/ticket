using System;
using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Operadores;
using Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaAtivacaoDoOperador;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public class AdaptadorDoRepositorioParaAtivacaoDoOperador : IAdaptadorDoRepositorioParaAtivacaoDoOperador
    {
        public DadosDoOperador AdaptarOperadorParaDados(Operador operador) => operador.ParaDados();
        public Operador AdaptarOperadorParaEntidade(DadosDoOperador operador) => operador.ParaEntidade();
    }
}
