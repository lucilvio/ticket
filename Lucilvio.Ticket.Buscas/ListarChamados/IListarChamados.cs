using System;
using System.Collections.Generic;
using System.Linq;

namespace Lucilvio.Ticket.Buscas.ListarChamados
{

    public interface IListarChamados : IBusca<IReadOnlyList<ChamadoDaLista>, QueryParaListarChamados>
    {
    }
}