using System;
using System.Collections.Generic;

namespace Lucilvio.Ticket.Testes
{
    public class Chamado
    {
        private readonly IList<Resposta> _respostas;

        public Chamado(Cliente cliente, Protocolo protocolo, string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new ChamadoNaoPodeSerAbertoSemDescricao();

            this.Cliente = cliente;
            this.Descricao = descricao;
            this.DataDaAbertura = DateTime.Now;
            this._respostas = new List<Resposta>();

            this.Protocolo = protocolo;
            this.TempDeAtendimento = 1;
        }

        public Cliente Cliente { get; }
        public string Descricao { get; }
        public DateTime DataDaAbertura { get; set; }

        internal void AdicionarResposta(Operador operador, string resposta)
        {
            this._respostas.Add(new Resposta(this, operador, resposta));
        }

        public Protocolo Protocolo { get; }
        public int TempDeAtendimento { get; }
    }
}