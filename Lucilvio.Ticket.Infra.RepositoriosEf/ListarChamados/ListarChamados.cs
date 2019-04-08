using Lucilvio.Ticket.Buscas;
using Lucilvio.Ticket.Buscas.ListarChamados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.ListarChamados
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
            return this._contexto.Chamados.Skip(query.Pagina * query.RegistrosPorPagina).Take(query.RegistrosPorPagina)
                .Select(c => new ChamadoDaLista(c.Protocolo, c.Descricao, c.Cliente.Nome, c.DataDaAbertura)).ToList();
        }
    }
}
