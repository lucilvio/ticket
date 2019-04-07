using System.Linq;
using Lucilvio.Ticket.Testes;

namespace Lucilvio.Ticket.Web.Chamados
{
    public class RepositorioParaAberturaDeChamado : IRepositorioParaAberturaDeChamado
    {
        private readonly IContexto _contexto;

        public RepositorioParaAberturaDeChamado(IContexto contexto)
        {
            this._contexto = contexto;
        }

        public void AbrirChamado(Chamado chamado)
        {
            this._contexto.Chamados.Add(chamado);
        }

        public Cliente PegarClientePeloLogin(string login)
        {
            return this._contexto.Clientes.FirstOrDefault(c => c.Login == login);
        }

        public int PegarProtocoloDoUltimoChamadoAberto()
        {
            var ultimaChamadoCriado = this._contexto.Chamados.LastOrDefault();
            return ultimaChamadoCriado == null ? 0 : ultimaChamadoCriado.Protocolo;
        }
    }
}
