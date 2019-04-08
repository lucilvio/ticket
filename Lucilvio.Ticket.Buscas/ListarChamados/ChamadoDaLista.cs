using System;
using System.Collections.Generic;
using System.Linq;

namespace Lucilvio.Ticket.Buscas.ListarChamados
{
    public class ChamadoDaLista
    {
        public ChamadoDaLista(int protocolo, string descricao, string cliente, DateTime dataDeAbertura)
        {
            this.Protocolo = protocolo.ToString();
            this.Descricao = descricao;
            this.Cliente = cliente;
            this.DataDaAbertura = dataDeAbertura.ToString();
        }

        public string Protocolo { get; set; }
        public string Descricao { get; set; }
        public string Cliente { get; set; }
        public string DataDaAbertura { get; set; }
    }
}