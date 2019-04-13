namespace Lucilvio.Ticket.Servicos.EntrarNoSistemaComoCliente
{
    public class ComandoParaEntrarNoSistemaComoCliente : IComando
    {
        public ComandoParaEntrarNoSistemaComoCliente(string login, string senha)
        {
            this.Login = login;
            this.Senha = senha;
        }

        public string Login { get; }
        public string Senha { get; }
    }
}
