using System;
using System.Collections.Generic;
using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Usuarios;

namespace Lucilvio.Ticket.Dominio.Clientes
{
    public sealed class Cliente : Entidade
    {
        private Cliente()
        {
            this.Chamados = new List<Chamado>();
            this.Contatos = new List<Contato>();
        }

        public Cliente(string nome, string email, string senha, params Contato[] contatos) : this()
        {
            this.Nome = nome;
            this.Email = email;
            this.Contatos = contatos;
            this.DataDoCadastro = DateTime.Now;
            this.Usuario = Usuario.Cliente(nome, email, email, senha);
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public Usuario Usuario { get; private set; }
        public DateTime DataDoCadastro { get; private set; }
        public IList<Chamado> Chamados { get; private set; }
        public IEnumerable<Contato> Contatos { get; private set; }

        public string Login => this.Usuario?.Login;
        public Usuario.PerfilDoUsuario? Perfil => this.Usuario?.Perfil;


        public Chamado AbrirChamado(Protocolo protocolo, string descricao)
        {
            var novoChamado = new Chamado(this, protocolo, descricao);
            this.Chamados.Add(novoChamado);
            
            return novoChamado;
        }

        public class Contato : Entidade
        {
            private Contato()
            {
            }

            public Contato(string valor, TipoDoContato tipo)
            {
                this.Valor = valor;
                this.Tipo = tipo;
            }

            public string Valor { get; private set; }
            public TipoDoContato Tipo { get; private set; }

            public enum TipoDoContato
            {
                Telefone = 0,
                Email = 1,
                RedeSocial = 2
            }
        }
    }
}