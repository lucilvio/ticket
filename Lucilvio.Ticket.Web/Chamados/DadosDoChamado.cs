using System;

namespace Lucilvio.Ticket.Web.Chamados
{
    public class DadosDoChamado
    {
        public int Protocolo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDeAbertura { get; internal set; }
    }
}