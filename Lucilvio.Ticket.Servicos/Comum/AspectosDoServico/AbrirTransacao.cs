using System;
using Lucilvio.Ticket.Servicos.Comum.ServicosExternos.Transacao;

namespace Lucilvio.Ticket.Servicos.Comum.AspectosDoServico
{
    public class AbrirTransacao<TComando> : IServico<TComando> where TComando : IComando
    {
        private readonly IServico<TComando> _servico;
        private readonly IServicoDeTransacao _servicoDeTransacao;

        public AbrirTransacao(IServico<TComando> servico, IServicoDeTransacao servicoDeTransacao)
        {
            this._servico = servico;
            this._servicoDeTransacao = servicoDeTransacao;
        }

        public void Executar(TComando comando)
        {
            try
            {
                this._servicoDeTransacao.Abrir();

                this._servico.Executar(comando);
            }
            catch (Exception)
            {
                this._servicoDeTransacao.Desfazer();
            }

            this._servicoDeTransacao.Comitar();
        }
    }
}
