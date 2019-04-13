using Lucilvio.Ticket.Dominio.Clientes;
using Lucilvio.Ticket.Servicos.CadastrarCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaCadastroDeCliente
{
    public class RepositorioParaCadastroDeCliente : IRepositorioParaCadastroDeCliente
    {
        private readonly Contexto _contexto;

        public RepositorioParaCadastroDeCliente(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public void AdicionarCliente(Cliente novoCliente)
        {
            this._contexto.Clientes.Add(novoCliente);
        }

        public void Persistir()
        {
            this._contexto.SaveChanges();
        }
    }
}
