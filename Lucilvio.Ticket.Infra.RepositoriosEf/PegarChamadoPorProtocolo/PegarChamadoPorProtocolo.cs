using Lucilvio.Ticket.Buscas.PegarChamadoPeloProtocolo;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.PegarChamadoPorProtocolo
{
    public class PegarChamadoPorProtocolo : IPegarChamadoPorProtocolo
    {
        private readonly Contexto _contexto;

        public PegarChamadoPorProtocolo(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public ChamadoDetalhado Executar(QueryParaPegarChamadoPorProtocolo query)
        {
            var chamado = this._contexto.Chamados.Include(c => c.Respostas).FirstOrDefault(c => c.Protocolo.Valor == query.Protocolo);

            return new ChamadoDetalhado(chamado.Protocolo, chamado.Descricao, chamado.DataDaAbertura, chamado.AbertoPor,
                chamado.Respostas.Select(r => new ChamadoDetalhado.RespostaDetalhada(r.Texto, r.Data, r.DadaPor)));
        }
    }
}
