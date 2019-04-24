using Lucilvio.Ticket.Dominio.Operadores;
using Lucilvio.Ticket.Servicos.CadastrarOperador;
using System.Linq;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaCadastroDeOperador
{
    public class RepositorioParaCadastroDeOperador : IRepositorioParaCadastroDeOperador
    {
        private readonly Contexto _contexto;

        public RepositorioParaCadastroDeOperador(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void AdicionarOperador(Operador operador)
        {
            this._contexto.Operadores.Add(operador);
        }

        public Operador PegarOperadorPorEmail(string email)
        {
            return this._contexto.Operadores.FirstOrDefault(o => o.Email == email);
        }

        public void Persistir()
        {
            this._contexto.SaveChanges();
        }
    }
}