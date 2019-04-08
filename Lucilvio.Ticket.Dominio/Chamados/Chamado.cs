﻿using System;
using System.Linq;
using System.Collections.Generic;
using Lucilvio.Ticket.Dominio.Clientes;
using Lucilvio.Ticket.Dominio.Operadores;

namespace Lucilvio.Ticket.Dominio.Chamados
{
    public class Chamado : Entidade
    {
        private Chamado()
        {
            this.Respostas = new List<Resposta>();
        }

        public Chamado(Cliente cliente, Protocolo protocolo, string descricao) :  this()
        {
            if (string.IsNullOrEmpty(descricao))
                throw new ChamadoNaoPodeSerAbertoSemDescricao();

            this.Cliente = cliente;
            this.Descricao = descricao;
            this.DataDaAbertura = DateTime.Now;

            this.Protocolo = protocolo;
        }

        public Protocolo Protocolo { get; private set; }
        public Cliente Cliente { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataDaAbertura { get; private set; }
        public IList<Resposta> Respostas { get; set; }

        public string AbertoPor => this.Cliente != null ? this.Cliente.Nome : "";

        internal void AdicionarResposta(Operador operador, string resposta)
        {
            this.Respostas.Add(new Resposta(this, operador, resposta));
        }
    }
}