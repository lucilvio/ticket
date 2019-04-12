using Lucilvio.Ticket.Buscas.ListarOperadores;
using System.Collections.Generic;
using System.Linq;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.ListarOperadores
{
    public class ListarOperadores : IListarOperadores
    {
        private readonly Contexto _contexto;

        public ListarOperadores(Contexto contexto)
        {
            _contexto = contexto;
        }

        public IReadOnlyList<OperadorDaLista> Executar(QueryParaListarOperadores query)
        {
            var operadores = this._contexto.Operadores.Skip(query.Pagina * query.RegistrosPorPagina).Take(query.RegistrosPorPagina).ToList();
            return operadores.Select(o => new OperadorDaLista(o.Id, o.Nome, o.Email, o.DataDoCadastro)).ToList();
        }
    }
}
