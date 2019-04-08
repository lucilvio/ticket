using Lucilvio.Ticket.Dominio.Operadores;
using System;

namespace Lucilvio.Ticket.Dominio.Chamados
{
    public class Resposta : Entidade
    {
        private Resposta()
        {
        }

        public Resposta(Chamado chamado, Operador operador, string texto)
        {
            this.Chamado = chamado;
            this.Operador = operador;
            this.Data = DateTime.Now;
            this.Texto = texto;
        }

        public string Texto { get; private set; }
        public Chamado Chamado { get; private set; }
        public Operador Operador { get; private set; }
        public DateTime Data { get; private set; }

        public string DadaPor => this.Operador != null ? this.Operador.Nome : "";
    }
}