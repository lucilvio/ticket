using System.Linq;
using Lucilvio.Ticket.Buscas.PegarChamadoPeloProtocolo;

namespace Lucilvio.Ticket.Infra.BuscasComDapper.PegarChamadoPorProtocolo
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
            using(var conexao = this._contexto.Conexao)
            {
                return null;
            }
        }
    }
}
