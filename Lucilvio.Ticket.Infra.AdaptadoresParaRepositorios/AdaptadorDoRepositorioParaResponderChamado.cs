using System;
using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Operadores;
using Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaResponderChamado;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public class AdaptadorDoRepositorioParaResponderChamado : IAdaptadorDoRepositorioParaResponderChamado
    {
        public Chamado AdaptarChamadoParaEntidade(DadosDoChamado chamado) => chamado.ParaEntidade();
        public Operador AdaptarOperadorParaEntidade(DadosDoOperador operador) => operador.ParaEntidade();
    }
}
