namespace Lucilvio.Ticket.Servicos.CadastrarOperador
{
    public class ComandoParaCadastrarOperador : IComando
    {
        public ComandoParaCadastrarOperador(string nome, string email, string senha, string confirmacaoDaSenha)
        {
            Nome = nome;
            Email = email;

            if (senha != confirmacaoDaSenha)
                throw new AsSenhasNaoConferem();

            this.Senha = senha;
        }

        public string Nome { get; }
        public string Email { get; }
        public string Senha { get; }
    }
}