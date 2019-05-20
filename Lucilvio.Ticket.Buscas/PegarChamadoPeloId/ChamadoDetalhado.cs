using System;
using System.Collections.Generic;

namespace Lucilvio.Ticket.Buscas.PegarChamadoPorId
{
    public class ChamadoDetalhado
    {
        public int Id { get; set; }
        public string Protocolo { get; set; }
        public string Descricao { get; set; }
        public string DataDaAbertura { get; set; }
        public string Cliente { get; set; }
        public IEnumerable<RespostaDetalhada> Respostas { get; set; }

        public class RespostaDetalhada
        {
            public string Resposta { get; set; }
            public string Data { get; set; }
            public string Operador { get; set; }
        }
    }
}