using System.Collections.Generic;

namespace Lucilvio.Ticket.Testes
{
    public class Chamado
    {
        private readonly Cliente _cliente;
        private readonly GeradorDeProtocolo _geradorDeProtocolo;
        private readonly IList<Resposta> _respostas;

        public Chamado(Cliente cliente, GeradorDeProtocolo geradorDeProtocolo, string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new FaltaDescricaoDoProblema();

            this._cliente = cliente;
            this.Descricao = descricao;
            this._respostas = new List<Resposta>();

            this._geradorDeProtocolo = geradorDeProtocolo.NovoProtocolo();
            this.TempDeAtendimento = 1;
        }

        public string Descricao { get; }

        internal void AdicionarResposta(Resposta resposta)
        {
            this._respostas.Add(resposta);
        }

        public string Protocolo { get => this._geradorDeProtocolo.NumeroDoUltimoProcotoloGerado; }
        public int TempDeAtendimento { get; }
    }
}