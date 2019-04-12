﻿using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Clientes;
using Lucilvio.Ticket.Dominio.Usuarios;
using System;

namespace Lucilvio.Ticket.Dominio.Operadores
{
    public class Operador : Entidade
    {
        private Operador()
        {
        }

        public Operador(string nome, string email, string senha)
        {
            this.Nome = nome;
            this.Email = email;
            this.Usuario = new Usuario(email, senha);

            this.DataDoCadastro = DateTime.Now;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public Usuario Usuario { get; private set; }
        public DateTime DataDoCadastro { get; private set; }

        public Chamado AbrirChamado(Cliente cliente, Protocolo.Gerador geradorDeProtocolo, string descricao)
        {
            return new Chamado(cliente, geradorDeProtocolo.NovoProtocolo(), descricao);
        }

        public void ResponderAoChamado(Chamado novoChamado, string resposta)
        {
            novoChamado.AdicionarResposta(this, resposta);
        }
    }
}