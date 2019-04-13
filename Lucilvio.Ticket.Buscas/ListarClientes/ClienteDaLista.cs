using Lucilvio.Ticket.Dominio.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lucilvio.Ticket.Buscas.ListarClientes
{
    public class ClienteDaLista
    {
        private readonly IEnumerable<Cliente.Contato> _contatos;

        public ClienteDaLista()
        {
            this._contatos = new List<Cliente.Contato>();
        }

        public ClienteDaLista(string nome, string email, DateTime dataDoCadastro, IEnumerable<Cliente.Contato> contatos) : this()
        {
            this.Nome = nome;
            this.Email = email;
            this._contatos = contatos;
            this.DataDoCadastro = dataDoCadastro.ToString();
        }

        public string Nome { get; }
        public string Email { get; }
        public string DataDoCadastro { get; }
        public IReadOnlyList<ContatoDoClienteDaLista> Contatos { get => this._contatos.Select(c => new ContatoDoClienteDaLista(c.Valor, c.Tipo.ToString())).ToList(); }

        public string Telefone => this._contatos.Any(c => c.Tipo == Cliente.Contato.TipoDoContato.Telefone)
            ? this._contatos.FirstOrDefault(c => c.Tipo == Cliente.Contato.TipoDoContato.Telefone).ToString()
            : string.Empty;

        public class ContatoDoClienteDaLista
        {
            public ContatoDoClienteDaLista(string contato, string tipo)
            {
                this.Contato = contato;
                this.Tipo = tipo;
            }

            public string Contato { get; }
            public string Tipo { get; }
        }
    }

}