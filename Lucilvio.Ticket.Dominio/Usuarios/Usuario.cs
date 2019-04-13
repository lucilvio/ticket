using System;

namespace Lucilvio.Ticket.Dominio.Usuarios
{
    public class Usuario : Entidade
    {
        private Usuario()
        {
        }

        private Usuario(string nome, string email, string login, string senha, PerfilDoUsuario perfil)
        {
            this.Nome = nome;
            this.Email = email;
            this.Login = login;
            this.Senha = senha;
            this.Perfil = perfil;
            this.DataDoCadastro = DateTime.Now;
        }

        public static Usuario Cliente(string nome, string email, string login, string senha) => new Usuario(nome, email, login, senha, PerfilDoUsuario.Cliente);
        public static Usuario Operador(string nome, string email, string login, string senha) => new Usuario(nome, email, login, senha, PerfilDoUsuario.Operador);

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public PerfilDoUsuario Perfil { get; private set; }
        public DateTime DataDoCadastro { get; private set; }

        public enum PerfilDoUsuario
        {
            Administrador = 1,
            Operador = 2,
            Cliente = 3
        }
    }
}