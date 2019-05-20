using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Clientes;
using System.Linq;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public static class AdaptadorParaDadosDoCliente
    {
        public static DadosDoCliente ParaDados(this Cliente cliente)
        {
            return new DadosDoCliente
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                DataDoCadastro = cliente.DataDoCadastro,
                Usuario = cliente.Usuario.ParaDados(),
                Chamados = cliente.Chamados.Select(c => c.ParaDados()).ToList(),
                Contatos = cliente.Contatos.Select(c => c.ParaDados()).ToList()
            };
        }
    }
}
