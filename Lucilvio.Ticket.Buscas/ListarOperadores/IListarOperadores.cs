using System.Collections.Generic;

namespace Lucilvio.Ticket.Buscas.ListarOperadores
{
    public interface IListarOperadores : IBusca<IReadOnlyList<OperadorDaLista>, QueryParaListarOperadores>
    {
    }
}
