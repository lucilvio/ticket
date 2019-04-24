using System.Linq;
using Lucilvio.Ticket.Dominio.Operadores;
using Lucilvio.Ticket.Servicos.InativarOperador;
using Microsoft.EntityFrameworkCore;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaInativacaoDoOperador
{
    public class RepositorioParaInativacaoDoOperador : IRepositorioParaInativacaoDoOperador
    {
        private readonly Contexto _contexto;

        public RepositorioParaInativacaoDoOperador(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public Operador PegarOperadorPeloId(int id)
        {
            return this._contexto.Operadores.Include(o => o.Usuario).FirstOrDefault(o => o.Id == id);
        }

        public void Persistir()
        {
            this._contexto.SaveChanges();
        }
    }
}
