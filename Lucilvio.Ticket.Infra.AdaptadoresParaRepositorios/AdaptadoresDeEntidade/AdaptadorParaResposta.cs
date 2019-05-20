using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Chamados;
using System;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public static class AdaptadorParaResposta
    {
        public static Resposta ParaEntidade(this DadosDeResposta dados)
        {
            var tipoDoDestino = typeof(Resposta);
            var destino = (Resposta)Activator.CreateInstance(tipoDoDestino, true);

            tipoDoDestino.GetProperty("Id").SetValue(destino, dados.Id);
            tipoDoDestino.GetProperty("Texto").SetValue(destino, dados.Texto);
            tipoDoDestino.GetProperty("Data").SetValue(destino, dados.Data);
            tipoDoDestino.GetProperty("Chamado").SetValue(destino, dados.Chamado.ParaEntidade());
            tipoDoDestino.GetProperty("Operador").SetValue(destino, dados.Operador.ParaEntidade());

            return destino;
        }
    }
}