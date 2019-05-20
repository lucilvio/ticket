using System;

namespace Lucilvio.Ticket.Dominio.Usuarios
{
    public sealed class Usuario : Entidade
    {
        private Usuario() { }

        private Usuario(string nome, string email, string login, string senha, PerfilDoUsuario perfil)
        {
            this.Nome = nome;
            this.Email = email;
            this.Login = login;
            this.Senha = senha;
            this.Perfil = perfil;
            this.DataDoCadastro = DateTime.Now;

            this.Ativar();
        }

        public static Usuario Cliente(string nome, string email, string login, string senha) => new Usuario(nome, email, login, senha, PerfilDoUsuario.Cliente);
        public static Usuario Operador(string nome, string email, string login, string senha) => new Usuario(nome, email, login, senha, PerfilDoUsuario.Operador);
        public static Usuario Administrador(string nome, string email, string login, string senha) => new Usuario(nome, email, login, senha, PerfilDoUsuario.Administrador);

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public bool Ativo { get; private set; }
        public PerfilDoUsuario Perfil { get; private set; }
        public DateTime DataDoCadastro { get; private set; }

        public bool Inativo => this.Ativo == false;

        internal void Inativar()
        {
            this.Ativo = false;
        }

        internal void Ativar()
        {
            this.Ativo = true;
        }

        public enum PerfilDoUsuario
        {
            Administrador = 1,
            Operador = 2,
            Cliente = 3
        }
    }
}