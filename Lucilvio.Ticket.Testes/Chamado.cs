namespace Lucilvio.Ticket.Testes
{
    internal class Chamado
    {
        private string _descricao;
        private Cliente _cliente;
        private GeradorDeProtocolo _geradorDeProtocolo;

        public Chamado(Cliente cliente, GeradorDeProtocolo geradorDeProtocolo, string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new FaltaDescricaoDoProblema();

            this._cliente = cliente;
            this._descricao = descricao;

            this._geradorDeProtocolo = geradorDeProtocolo.NovoProtocolo();
            this.TempDeAtendimento = 1;
        }

        public string Protocolo { get => this._geradorDeProtocolo.NumeroDoUltimoProcotoloGerado; }
        public int TempDeAtendimento { get; }
    }
}