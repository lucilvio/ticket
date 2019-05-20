using Dapper;
using System.Linq;
using Lucilvio.Ticket.Buscas.PegarChamadoPorId;

namespace Lucilvio.Ticket.Infra.BuscasComDapper.PegarChamadoPorId
{
    public class PegarChamadoPorId : IPegarChamadoPorId
    {
        private readonly Contexto _contexto;

        public PegarChamadoPorId(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public ChamadoDetalhado Executar(QueryParaPegarChamadoPorId query)
        {
            using(var conexao = this._contexto.Conexao)
            {
                var chamado = conexao.QuerySingleOrDefault<ChamadoDetalhado>(@"select c.Id, c.Protocolo, c.Descricao, c.DataDaAbertura, cl.Nome as Cliente
                    from Chamados c inner join Clientes cl on cl.Id = c.ClienteId 
                    where c.Id = @id", query);

                if (chamado == null)
                    return chamado;

                chamado.Respostas = conexao.Query<ChamadoDetalhado.RespostaDetalhada>(@"select r.Id, r.Texto, r.Data, o.Nome as Operador
                    from RespostasDosChamados r inner join Operadores o on o.Id = r.OperadorId
                    where r.ChamadoId = @id", query).ToList();

                return chamado;
            }
        }
    }
}
