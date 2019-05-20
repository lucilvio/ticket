using System.Linq;
using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Operadores;
using Lucilvio.Ticket.Infra.RepositoriosEf.Comum;
using Lucilvio.Ticket.Servicos.ResponderChamado;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaResponderChamado
{
    public class RepositorioParaResponderChamado : IRepositorioParaResponderChamado
    {
        private readonly Contexto _contexto;
        private readonly IAdaptadorDoRepositorioParaResponderChamado _adaptador;

        public RepositorioParaResponderChamado(Contexto contexto, IAdaptadorDoRepositorioParaResponderChamado adaptador)
        {
            this._contexto = contexto;
            this._adaptador = adaptador;
        }

        public Chamado PegarChamadoPeloProtocolo(int chamado)
        {
            return this._adaptador.AdaptarChamadoParaEntidade(this._contexto.Chamados.FirstOrDefault(c => c.Protocolo == chamado));
        }

        public Operador PegarOperadorPeloLogin(string login)
        {
            return this._adaptador.AdaptarOperadorParaEntidade((this._contexto.Operadores.FirstOrDefault(o => o.Usuario.Login == login)));
        }

        public void Persistir()
        {
            this._contexto.SaveChanges();
        }
    }
}