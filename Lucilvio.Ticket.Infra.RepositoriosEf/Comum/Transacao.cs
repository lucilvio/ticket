using Microsoft.EntityFrameworkCore.Storage;
using Lucilvio.Ticket.Servicos.Comum.ServicosExternos.Transacao;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.Comum
{
    public class Transacao : IServicoDeTransacao
    {
        private readonly Contexto _contexto;
        private IDbContextTransaction _transacao;

        public Transacao(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public void Abrir()
        {
            this._transacao = this._contexto.Database.BeginTransaction();
        }

        public void Comitar()
        {
            this._transacao.Commit();
        }

        public void Desfazer()
        {
            this._transacao.Rollback();
        }
    }
}