using Dapper;
using System.Linq;
using System.Collections.Generic;
using Lucilvio.Ticket.Buscas.ListarChamados;

namespace Lucilvio.Ticket.Infra.BuscasComDapper.ListarChamados
{
    public class ListarChamados : IListarChamados
    {
        private readonly Contexto _contexto;

        public ListarChamados(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public IReadOnlyList<ChamadoDaLista> Executar(QueryParaListarChamados query)
        {
            using (var conexao = this._contexto.Conexao)
            {
                return conexao.Query<ChamadoDaLista>(@"select c.Id, c.Protocolo, c.Descricao, c.DataDaAbertura, cl.Nome as Cliente 
                    from Chamados c inner join Clientes cl on c.ClienteId = cl.Id order by c.Id
                    offset @pagina * @registrosPorPagina rows fetch next @registrosPorPagina rows only", query).ToList();
            }
        }
    }
}
