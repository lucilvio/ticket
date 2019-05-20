using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Operadores;
using Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaCadastroDeOperador;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public class AdaptadorDoRepositorioParaCadastroDeOperador : IAdaptadorDoRepositorioParaCadastroDeOperador
    {
        public DadosDoOperador AdaptarOperadorParaDados(Operador operador) => operador.ParaDados();
    }
}