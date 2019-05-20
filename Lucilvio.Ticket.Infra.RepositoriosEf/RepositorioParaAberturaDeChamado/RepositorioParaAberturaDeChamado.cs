using System.Linq;
using Lucilvio.Ticket.Dominio.Clientes;
using Lucilvio.Ticket.Servicos.AbrirChamado;
using Lucilvio.Ticket.Infra.RepositoriosEf.Comum;
using Lucilvio.Ticket.Dominio.Chamados;
using Microsoft.EntityFrameworkCore;

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
            return this._adaptador.AdaptarClienteParaEntidade(this._contexto.Clientes.Include(c => c.Chamados).FirstOrDefault(c => c.Usuario.Login == login));
        }

        public int PegarProtocoloDoUltimoChamadoAberto()
        {
            var ultimaChamadoCriado = this._contexto.Chamados.LastOrDefault();
            return ultimaChamadoCriado == null ? 0 : ultimaChamadoCriado.Protocolo;
        }

        public void Persistir(Cliente cliente)
        {
            this._contexto.Update(this._adaptador.AdaptarChamadoParaDados(cliente));
            this._contexto.SaveChanges();
        }
    }
}