using System;
using System.Collections.Generic;

namespace Lucilvio.Ticket.Testes
{
    internal class Cliente
    {
        private IList<Chamado> _chamados;

        public Cliente()
        {
            this._chamados = new List<Chamado>();
        }

        internal Chamado AbrirChamado(GeradorDeProtocolo geradorDeProtocolo, string descricao, IServicoDeNotificacao servicoDeNotificacao)
        {
            var novoChamado = new Chamado(geradorDeProtocolo, descricao);
            this._chamados.Add(novoChamado);

            var notificacao = new Notificacao(novoChamado.Protocolo, novoChamado.TempDeAtendimento);
            servicoDeNotificacao.Notificar(notificacao);

            return novoChamado;
        }
    }
}