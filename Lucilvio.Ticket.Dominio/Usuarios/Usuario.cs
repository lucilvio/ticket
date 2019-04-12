namespace Lucilvio.Ticket.Dominio.Usuarios
{
    public class Usuario : Entidade
    {
        private Usuario()
        {
        }

        public Usuario(string login, string senha)
        {
            this.Login = login;
            this.Senha = senha;
        }

        public string Login { get; private set; }
        public string Senha { get; private set; }
    }
}