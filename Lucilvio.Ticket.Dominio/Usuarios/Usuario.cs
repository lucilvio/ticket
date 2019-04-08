namespace Lucilvio.Ticket.Dominio.Usuarios
{
    public class Usuario : Entidade
    {
        private Usuario()
        {
        }

        public Usuario(string login)
        {
            this.Login = login;
        }

        public string Login { get; private set; }
    }
}