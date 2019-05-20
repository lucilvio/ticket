using System.Linq;
using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Chamados;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public static class AdaptadorParaDadosDaResposta
    {
        public static DadosDeResposta ParaDados(this Resposta resposta)
        {
            return new DadosDeResposta
            {
                Id = resposta.Id,
                Texto = resposta.Texto,
                Data = resposta.Data,
                Chamado = resposta.Chamado.ParaDados(),
                Operador = resposta.Operador.ParaDados()
            };
        }
    }
}
