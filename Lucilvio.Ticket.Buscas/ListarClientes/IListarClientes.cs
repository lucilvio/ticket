using System.Collections.Generic;

namespace Lucilvio.Ticket.Buscas.ListarClientes
{
    public interface IListarClientes : IBusca<IReadOnlyList<ClienteDaLista>, QueryParaListarClientes>
    {
        
    }
}
