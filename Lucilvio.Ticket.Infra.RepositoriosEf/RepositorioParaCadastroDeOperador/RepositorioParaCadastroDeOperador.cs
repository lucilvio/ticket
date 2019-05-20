using System.Linq;
using Lucilvio.Ticket.Dominio.Operadores;
using Lucilvio.Ticket.Servicos.CadastrarOperador;
using Lucilvio.Ticket.Infra.RepositoriosEf.Comum;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaCadastroDeOperador
{
    public class RepositorioParaCadastroDeOperador : IRepositorioParaCadastroDeOperador
    {
        private readonly Contexto _contexto;
        private readonly IAdaptadorDoRepositorioParaCadastroDeOperador _adaptador;

        public RepositorioParaCadastroDeOperador(Contexto contexto, IAdaptadorDoRepositorioParaCadastroDeOperador adaptador)
        {
            _contexto = contexto;
            this._adaptador = adaptador;
        }

        public void AdicionarOperador(Operador operador)
        {
            this._contexto.Operadores.Add(this._adaptador.AdaptarOperadorParaDados(operador));
        }

        public bool ExisteOperadorComOEmail(string email)
        {
            return this._contexto.Operadores.Any(o => o.Email == email);
        }

        public void Persistir()
        {
            this._contexto.SaveChanges();
        }
    }
}