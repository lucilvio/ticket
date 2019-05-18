using System;
using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Clientes;
using Lucilvio.Ticket.Dominio.Usuarios;

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
            this.Usuario = Usuario.Operador(nome, email, email, senha);

            this.DataDoCadastro = DateTime.Now;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public Usuario Usuario { get; private set; }
        public DateTime DataDoCadastro { get; private set; }
        public bool Ativo { get; private set; }


        public Chamado AbrirChamado(Cliente cliente, Protocolo protocolo, string descricao)
        {
            return new Chamado(cliente, protocolo, descricao);
        }

        public void ResponderAoChamado(Chamado novoChamado, string resposta)
        {
            novoChamado.AdicionarResposta(this, resposta);
        }

        public void Ativar()
        {
            if (!this.JaEstaInativo)
                throw new OperadorJaEstaAtivo();

            this.Ativo = true;
            this.Usuario.Ativar();
        }

        public void Inativar()
        {
            if (this.JaEstaInativo)
                throw new OperadaroJaEstaInativo();

            this.Ativo = false;
            this.Usuario.Inativar();
        }

        private bool JaEstaInativo => this.Ativo == false;
    }

    
}