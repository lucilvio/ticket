namespace Lucilvio.Ticket.Testes
{
    internal class Chamado
    {
        private string _descricao;
        private GeradorDeProtocolo _geradorDeProtocolo;

        public Chamado(GeradorDeProtocolo geradorDeProtocolo, string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new FaltaDescricaoDoProblema();

            this._descricao = descricao;

            this._geradorDeProtocolo = geradorDeProtocolo.NovoProtocolo();
            this.TempDeAtendimento = 1;
        }

        public string Protocolo { get => this._geradorDeProtocolo.NumeroDoUltimoProcotoloGerado; }
        public int TempDeAtendimento { get; }
    }
}