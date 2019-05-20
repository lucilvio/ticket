using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Clientes;
using Lucilvio.Ticket.Dominio.Chamados;
using System.Linq;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public static class AdaptadorParaDadosDoChamado
    {
        public static DadosDoChamado ParaDados(this Chamado chamado)
        {
            return new DadosDoChamado
            {
                Id = chamado.Id,
                Descricao = chamado.Descricao,
                Protocolo = chamado.Protocolo,
                DataDaAbertura = chamado.DataDaAbertura,
                //Cliente = chamado.Cliente.ParaDados(),
                Respostas = chamado.Respostas.Select(r => r.ParaDados()).ToList()
            };
        }
    }
}
