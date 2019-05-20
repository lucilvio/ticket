using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Clientes;
using System.Linq;
using static Lucilvio.Ticket.Dominio.Clientes.Cliente;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public static class AdaptadorParaDadosDoContato
    {
        public static DadosDoContato ParaDados(this Contato contato)
        {
            return new DadosDoContato
            {
                Id = contato.Id,
                Tipo = (int)contato.Tipo,
                Valor = contato.Valor,
            };
        }
    }
}
