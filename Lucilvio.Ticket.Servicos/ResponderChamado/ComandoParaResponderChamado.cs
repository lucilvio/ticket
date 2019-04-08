namespace Lucilvio.Ticket.Servicos.ResponderChamado
{
    public class ComandoParaResponderChamado : IComando
    {
        public ComandoParaResponderChamado(string resposta, int chamado, string operador)
        {
            this.Resposta = resposta;
            this.Chamado = chamado;
            this.Operador = operador;
        }

        public string Resposta { get; }
        public int Chamado { get; }
        public string Operador { get; }
    }
}