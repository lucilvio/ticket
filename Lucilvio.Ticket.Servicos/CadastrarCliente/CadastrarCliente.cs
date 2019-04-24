using Lucilvio.Ticket.Dominio.Clientes;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Servicos.CadastrarCliente
{
    public class CadastrarCliente : IServico<ComandoParaCadastrarCliente>
    {
        private readonly IRepositorioParaCadastroDeCliente _repositorio;

        public CadastrarCliente(IRepositorioParaCadastroDeCliente repositorio)
        {
            this._repositorio = repositorio;
        }

        public void Executar(ComandoParaCadastrarCliente comando)
        {
            var novoCliente = new Cliente(comando.Nome, comando.Email, comando.Senha, comando.Contatos
                .Select(c => new Cliente.Contato(c.Valor, (Cliente.Contato.TipoDoContato)Enum.Parse(typeof(Cliente.Contato.TipoDoContato), c.Tipo))).ToArray());

            this._repositorio.AdicionarCliente(novoCliente);
            this._repositorio.Persistir();
        }
    }
}
