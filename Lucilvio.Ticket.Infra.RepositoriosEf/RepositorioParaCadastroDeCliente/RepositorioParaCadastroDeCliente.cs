using Lucilvio.Ticket.Dominio.Clientes;
using Lucilvio.Ticket.Infra.RepositoriosEf.Comum;
using Lucilvio.Ticket.Servicos.CadastrarCliente;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaCadastroDeCliente
{
    public class RepositorioParaCadastroDeCliente : IRepositorioParaCadastroDeCliente
    {
        private readonly Contexto _contexto;
        private readonly IAdaptadorDoRepositorioParaCadastroDeCliente _adaptador;

        public RepositorioParaCadastroDeCliente(Contexto contexto, IAdaptadorDoRepositorioParaCadastroDeCliente adaptador)
        {
            this._contexto = contexto;
            this._adaptador = adaptador;
        }

        public void AdicionarCliente(Cliente novoCliente)
        {
            this._contexto.Clientes.Add(this._adaptador.AdaptarClienteParaDados(novoCliente));
        }

        public void Persistir()
        {
            this._contexto.SaveChanges();
        }
    }
}
