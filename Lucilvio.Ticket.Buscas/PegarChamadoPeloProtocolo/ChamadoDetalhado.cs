using System;
using System.Collections.Generic;

namespace Lucilvio.Ticket.Buscas.PegarChamadoPeloProtocolo
{
    public class ChamadoDetalhado
    {
        public ChamadoDetalhado(int protocolo, string descricao, DateTime dataDeAbertura, string cliente, IEnumerable<RespostaDetalhada> respostas)
        {
            this.Protocolo = protocolo.ToString();
            this.Descricao = descricao;
            this.DataDaAbertura = dataDeAbertura.ToString();
            this.Cliente = cliente;
            this.Respostas = respostas;
        }

        public string Protocolo { get; }
        public string Descricao { get; }
        public string DataDaAbertura { get; }
        public string Cliente { get; }
        public IEnumerable<RespostaDetalhada> Respostas { get; }

        public class RespostaDetalhada
        {
            public RespostaDetalhada(string resposta, DateTime data, string operador)
            {
                this.Resposta = resposta;
                this.Data = data.ToString();
                this.Operador = operador;
            }

            public string Resposta { get; }
            public string Data { get; }
            public string Operador { get; }
        }
    }
}