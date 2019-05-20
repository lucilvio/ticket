using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Clientes;
using System;
using static Lucilvio.Ticket.Dominio.Clientes.Cliente;
using static Lucilvio.Ticket.Dominio.Clientes.Cliente.Contato;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public static class AdaptadorParaContato
    {
        public static Contato ParaEntidade(this DadosDoContato dados)
        {
            var tipoDoDestino = typeof(Cliente.Contato);
            var destino = (Cliente.Contato)Activator.CreateInstance(tipoDoDestino, true);

            tipoDoDestino.GetProperty("Id").SetValue(destino, dados.Id);
            tipoDoDestino.GetProperty("Valor").SetValue(destino, dados.Valor);
            tipoDoDestino.GetProperty("Tipo").SetValue(destino, (TipoDoContato)dados.Tipo);
            tipoDoDestino.GetProperty("Cliente").SetValue(destino, dados.Cliente.ParaEntidade());

            return destino;
        }
    }
}