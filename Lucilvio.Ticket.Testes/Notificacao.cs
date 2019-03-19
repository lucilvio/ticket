namespace Lucilvio.Ticket.Testes
{
    internal class Notificacao
    {
        private string _texto;

        public Notificacao(string protocolo, object tempoDeAtendimento)
        {
            this._texto = $"Chamado criado, protocolo {protocolo}. Será atendido em {tempoDeAtendimento} hora(s)";
        }
    }
}