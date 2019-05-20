using System.Linq;
using Lucilvio.Ticket.Dominio.Clientes;
using Lucilvio.Ticket.Servicos.AbrirChamado;
using Lucilvio.Ticket.Infra.RepositoriosEf.Comum;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaAberturaDeChamado
{
    public class RepositorioParaAberturaDeChamado : IRepositorioParaAberturaDeChamado
    {
        private readonly Contexto _contexto;
        private readonly IAdaptadorDoRepositorioParaAberturaDeChamado _adaptador;

        public RepositorioParaAberturaDeChamado(Contexto contexto, IAdaptadorDoRepositorioParaAberturaDeChamado adaptador)
        {
            this._contexto = contexto;
            this._adaptador = adaptador;
        }

        public Cliente PegarClientePeloLogin(string login)
        {
            return this._adaptador.AdaptarClienteParaEntidade(this._contexto.Clientes.FirstOrDefault(c => c.Usuario.Login == login));
        }

        public int PegarProtocoloDoUltimoChamadoAberto()
        {
            var ultimaChamadoCriado = this._contexto.Chamados.LastOrDefault();
            return ultimaChamadoCriado == null ? 0 : ultimaChamadoCriado.Protocolo;
        }

        public void Persistir()
        {
            this._contexto.SaveChanges();
        }
    }
}