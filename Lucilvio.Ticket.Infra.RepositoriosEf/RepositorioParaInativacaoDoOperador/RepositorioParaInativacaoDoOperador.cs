using System.Linq;
using Microsoft.EntityFrameworkCore;
using Lucilvio.Ticket.Dominio.Operadores;
using Lucilvio.Ticket.Servicos.InativarOperador;
using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Infra.RepositoriosEf.Comum;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaInativacaoDoOperador
{
    public class RepositorioParaInativacaoDoOperador : IRepositorioParaInativacaoDoOperador
    {
        private readonly Contexto _contexto;
        private readonly IAdaptadorDoRepositorioParaInativacaoDoOperador _adaptador;

        public RepositorioParaInativacaoDoOperador(Contexto contexto, IAdaptadorDoRepositorioParaInativacaoDoOperador adaptador)
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