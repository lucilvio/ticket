using System;

namespace Lucilvio.Ticket.Testes
{
    internal class Operador
    {
        public Operador()
        {
        }

        internal Chamado AbrirChamado(Cliente cliente, Protocolo.Gerador geradorDeProtocolo, string descricao)
        {
            return new Chamado(cliente, geradorDeProtocolo.NovoProtocolo(), descricao);
        }

        internal void ResponderAoChamado(Chamado novoChamado, string resposta)
        {
            novoChamado.AdicionarResposta(this, resposta);
        }
    }
}