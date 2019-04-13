namespace Lucilvio.Ticket.Servicos.Comum
{
    public class SenhasParaConferencia
    {
        public SenhasParaConferencia(string senha, string confirmacaoDaSenha)
        {
            if (!senha.Equals(confirmacaoDaSenha))
                throw new AsSenhasNaoConferem();

            this.Senha = senha;
        }

        public string Senha { get; }
    }
}
