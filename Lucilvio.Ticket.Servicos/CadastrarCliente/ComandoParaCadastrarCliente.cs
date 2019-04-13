using Lucilvio.Ticket.Servicos.Comum;
using System;
using System.Collections.Generic;

namespace Lucilvio.Ticket.Servicos.CadastrarCliente
{
    public class ComandoParaCadastrarCliente : IComando
    {
        private ComandoParaCadastrarCliente()
        {
            this.Contatos = new List<Contato>();
        }

        public ComandoParaCadastrarCliente(string nome, string email, SenhasParaConferencia senhaParaConferencia, IEnumerable<Contato> contatos) : this()
        {
            Nome = nome;
            Email = email;

            this.Senha = senhaParaConferencia.Senha;

            Contatos = contatos;
        }

        public string Nome { get; }
        public string Email { get; }
        public string Senha { get; set; }
        public IEnumerable<Contato> Contatos { get; private set; }

        public class Contato
        {
            public Contato(string valor, string tipo)
            {
                this.Valor = valor;
                this.Tipo = tipo;
            }

            public string Valor { get; set; }
            public string Tipo { get; set; }
        }
    }
}
