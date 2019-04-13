using Lucilvio.Ticket.Servicos.Comum;

namespace Lucilvio.Ticket.Servicos.CadastrarOperador
{
    public class ComandoParaCadastrarOperador : IComando
    {
        public ComandoParaCadastrarOperador(string nome, string email, SenhasParaConferencia senhaParaConferecnia)
        {
            Nome = nome;
            Email = email;

            this.Senha = senhaParaConferecnia.Senha;
        }

        public string Nome { get; }
        public string Email { get; }
        public string Senha { get; }
    }
}