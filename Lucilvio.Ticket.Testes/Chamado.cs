using System.Collections.Generic;

namespace Lucilvio.Ticket.Testes
{
    internal class Chamado
    {
        private readonly string _descricao;
        private readonly Cliente _cliente;
        private readonly GeradorDeProtocolo _geradorDeProtocolo;
        private readonly IList<string> _respostas;

        public Chamado(Cliente cliente, GeradorDeProtocolo geradorDeProtocolo, string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new FaltaDescricaoDoProblema();

            this._cliente = cliente;
            this._descricao = descricao;
            this._respostas = new List<string>();

            this._geradorDeProtocolo = geradorDeProtocolo.NovoProtocolo();
            this.TempDeAtendimento = 1;
        }

        internal void AdicionarResposta(string resposta)
        {
            this._respostas.Add(resposta);
        }

        public string Protocolo { get => this._geradorDeProtocolo.NumeroDoUltimoProcotoloGerado; }
        public int TempDeAtendimento { get; }
    }
}