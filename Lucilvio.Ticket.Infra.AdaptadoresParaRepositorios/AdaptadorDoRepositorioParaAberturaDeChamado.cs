using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Clientes;
using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaAberturaDeChamado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public class AdaptadorDoRepositorioParaAberturaDeChamado : IAdaptadorDoRepositorioParaAberturaDeChamado
    {
        public DadosDoChamado AdaptarChamadoParaDados(Chamado chamado) => chamado.ParaDados();
        public Cliente AdaptarClienteParaEntidade(DadosDoCliente cliente) => cliente.ParaEntidade();
    }
}
