using System.Linq;
using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Chamados;
using System;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public static class AdaptadorParaChamado
    {
        public static Chamado ParaEntidade(this DadosDoChamado dados)
        {
            if (dados == null)
                return null;

            var tipoDoDestino = typeof(Chamado);
            var destino = (Chamado)Activator.CreateInstance(tipoDoDestino, true);

            tipoDoDestino.GetProperty("Id").SetValue(destino, dados.Id);
            tipoDoDestino.GetProperty("Protocolo").SetValue(destino, new Protocolo(dados.Protocolo));
            tipoDoDestino.GetProperty("Descricao").SetValue(destino, dados.Descricao);
            tipoDoDestino.GetProperty("DataDaAbertura").SetValue(destino, dados.DataDaAbertura);

            if (dados.Respostas != null)
                tipoDoDestino.GetProperty("Respostas").SetValue(destino, dados.Respostas.Select(r => r.ParaEntidade()));

            return destino;
        }
    }
}