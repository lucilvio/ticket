namespace Lucilvio.Ticket.Testes
{
    public class Notificacao
    {
        private string _texto;

        public Notificacao(int protocolo, object tempoDeAtendimento)
        {
            this._texto = $"Chamado criado, protocolo {protocolo}. Será atendido em {tempoDeAtendimento} hora(s)";
        }
    }
}