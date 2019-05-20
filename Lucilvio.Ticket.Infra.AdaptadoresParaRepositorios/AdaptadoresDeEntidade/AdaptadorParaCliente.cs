using System.Linq;
using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Clientes;
using System;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public static class AdaptadorParaCliente
    {
        public static Cliente ParaEntidade(this DadosDoCliente dados)
        {
            var tipoDoDestino = typeof(Cliente);
            var destino = (Cliente)Activator.CreateInstance(tipoDoDestino, true);

            tipoDoDestino.GetProperty("Nome").SetValue(destino, dados.Nome);
            tipoDoDestino.GetProperty("Email").SetValue(destino, dados.Email);
            tipoDoDestino.GetProperty("DataDoCadastro").SetValue(destino, dados.DataDoCadastro);
            tipoDoDestino.GetProperty("Usuario").SetValue(destino, dados.Usuario.ParaEntidade());
            tipoDoDestino.GetProperty("Chamados").SetValue(destino, dados.Chamados.Select(c => c.ParaEntidade()));
            tipoDoDestino.GetProperty("Contatos").SetValue(destino, dados.Contatos.Select(c => c.ParaEntidade()));

            return destino;
        }
    }
}