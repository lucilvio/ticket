using Lucilvio.Ticket.Dominio.Operadores;
using Lucilvio.Ticket.Servicos.AtivarOperador;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaAtivacaoDoOperador
{
    public class RepositorioParaAtivacaoDoOperador : IRepositorioParaAtivacaoDoOperador
    {
        private readonly Contexto _contexto;

        public RepositorioParaAtivacaoDoOperador(Contexto contexto)
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
