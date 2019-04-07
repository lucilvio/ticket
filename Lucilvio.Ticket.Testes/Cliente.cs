using System.Collections.Generic;

namespace Lucilvio.Ticket.Testes
{
    public class Cliente
    {
        private IList<Chamado> _chamados;

        public Cliente(string login, string nome)
        {
            this.Login = login;
            this._chamados = new List<Chamado>();
        }

        public string Login { get; }
        public string Nome { get; set; }

        public Chamado AbrirChamado(Protocolo protocolo, string descricao, IServicoDeNotificacao servicoDeNotificacao)
        {
            var novoChamado = new Chamado(this, protocolo, descricao);
            this._chamados.Add(novoChamado);

            var notificacao = new Notificacao(novoChamado.Protocolo.ToString(), novoChamado.TempDeAtendimento);
            servicoDeNotificacao.Notificar(notificacao);

            return novoChamado;
        }
    }
}