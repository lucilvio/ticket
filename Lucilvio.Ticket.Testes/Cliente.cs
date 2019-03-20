using System.Collections.Generic;

namespace Lucilvio.Ticket.Testes
{
    public class Cliente
    {
        private IList<Chamado> _chamados;

        public Cliente(string login)
        {
            this.Login = login;
            this._chamados = new List<Chamado>();
        }

        public string Login { get; }

        public Chamado AbrirChamado(GeradorDeProtocolo geradorDeProtocolo, string descricao, IServicoDeNotificacao servicoDeNotificacao)
        {
            var novoChamado = new Chamado(this, geradorDeProtocolo, descricao);
            this._chamados.Add(novoChamado);

            var notificacao = new Notificacao(novoChamado.Protocolo, novoChamado.TempDeAtendimento);
            servicoDeNotificacao.Notificar(notificacao);

            return novoChamado;
        }
    }
}