using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Operadores;
using Lucilvio.Ticket.Infra.RepositoriosEf.Comum;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaCadastroDeOperador
{
    public interface IAdaptadorDoRepositorioParaCadastroDeOperador: IAdaptador
    {
        DadosDoOperador AdaptarOperadorParaDados(Operador operador);
    }
}