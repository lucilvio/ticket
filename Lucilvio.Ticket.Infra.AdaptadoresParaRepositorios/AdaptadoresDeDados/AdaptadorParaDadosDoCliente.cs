using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Clientes;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public static class AdaptadorParaDadosDoCliente
    {
        public static DadosDoCliente ParaDados(this Cliente cliente)
        {
            return new DadosDoCliente
            {
                Nome = cliente.Nome,
                Email = cliente.Email,
                DataDoCadastro = cliente.DataDoCadastro,
                Usuario = cliente.Usuario.ParaDados()
            };
        }
    }
}
