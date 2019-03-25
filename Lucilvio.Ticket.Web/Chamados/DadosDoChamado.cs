using System;

namespace Lucilvio.Ticket.Web.Chamados
{
    public class DadosDoChamado
    {
        public string Cliente { get; set; }
        public string Protocolo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDeAbertura { get; internal set; }
    }
}