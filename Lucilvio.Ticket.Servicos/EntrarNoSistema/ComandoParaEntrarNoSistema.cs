namespace Lucilvio.Ticket.Servicos.EntrarNoSistema
{
    public class ComandoParaEntrarNoSistema : IComando
    {
        public ComandoParaEntrarNoSistema(string login, string senha)
        {
            this.Login = login;
            this.Senha = senha;
        }

        public string Login { get; }
        public string Senha { get; }
    }
}
