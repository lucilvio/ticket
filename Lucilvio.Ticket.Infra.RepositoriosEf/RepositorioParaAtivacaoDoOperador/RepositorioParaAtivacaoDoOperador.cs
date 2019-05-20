using System.Linq;
using Microsoft.EntityFrameworkCore;
using Lucilvio.Ticket.Dominio.Operadores;
using Lucilvio.Ticket.Servicos.AtivarOperador;
using Lucilvio.Ticket.Infra.RepositoriosEf.Comum;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaAtivacaoDoOperador
{
    public class RepositorioParaAtivacaoDoOperador : IRepositorioParaAtivacaoDoOperador
    {
        private readonly Contexto _contexto;
        private readonly IAdaptadorDoRepositorioParaAtivacaoDoOperador _adaptador;

        public RepositorioParaAtivacaoDoOperador(Contexto contexto, IAdaptadorDoRepositorioParaAtivacaoDoOperador adaptador)
        {
            this._contexto = contexto;
            this._adaptador = adaptador;
        }

        public Operador PegarOperadorPeloId(int id)
        {
            return this._adaptador.AdaptarOperadorParaEntidade(this._contexto.Operadores.Include(o => o.Usuario).FirstOrDefault(o => o.Id == id));
        }

        public void Persistir()
        {
            this._contexto.SaveChanges();
        }
    }
}
