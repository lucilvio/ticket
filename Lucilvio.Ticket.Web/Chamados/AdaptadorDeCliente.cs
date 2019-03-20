using Lucilvio.Ticket.Testes;

namespace Lucilvio.Ticket.Web.Chamados
{
    public class AdaptadorDeCliente : IAdaptadorDeCliente
    {
        public Cliente Entidade(DadosDoCliente dados)
        {
            if (dados == null)
                return new ClienteVazio();

            return new Cliente(dados.Login);
        }
    }

    internal class ClienteVazio : Cliente
    {
        public ClienteVazio() : base("")
        {
        }
    }
}
