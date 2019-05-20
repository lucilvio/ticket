using System;
using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Clientes;
using Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaCadastroDeCliente;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public class AdaptadorDoRepositorioParaCadastroDeCliente : IAdaptadorDoRepositorioParaCadastroDeCliente
    {
        public DadosDoCliente AdaptarClienteParaDados(Cliente cliente) => cliente.ParaDados();
    }
}
