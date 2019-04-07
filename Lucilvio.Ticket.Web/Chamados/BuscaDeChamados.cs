using System;
using System.Collections.Generic;
using System.Linq;

namespace Lucilvio.Ticket.Web.Chamados
{

    internal class ListarChamados : IBusca<IReadOnlyList<ChamadoDaLista>, QueryParaListarChamados>
    {
        private readonly IContexto _contexto;

        public ListarChamados(IContexto contexto)
        {
            this._contexto = contexto;
        }

        public IReadOnlyList<ChamadoDaLista> Executar(QueryParaListarChamados query)
        {
            var chamados = this._contexto.Chamados.Skip(query.Pagina * query.RegistrosPorPagina).Take(query.RegistrosPorPagina);

            return chamados.Select(c => new ChamadoDaLista(c.Protocolo, c.Descricao, c.Cliente.Nome, c.DataDaAbertura)).ToList();
        }
    }
}