using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Operadores;
using Lucilvio.Ticket.Servicos.ResponderChamado;
using System.Linq;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaResponderChamado
{
    public class RepositorioParaResponderChamado : IRepositorioParaResponderChamado
    {
        private readonly Contexto _contexto;

        public RepositorioParaResponderChamado(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public Chamado PegarChamadoPeloProtocolo(int chamado)
        {
            return this._contexto.Chamados.FirstOrDefault(c => c.Protocolo == chamado);
        }

        public Operador PegarOperadorPeloLogin(string login)
        {
            var operador = this._contexto.Operadores.FirstOrDefault(o => o.Usuario.Login == login);

            if(operador == null)
            {
                this._contexto.Operadores.Add(new Operador("operador", "operador"));
                this._contexto.SaveChanges();

                operador = this._contexto.Operadores.FirstOrDefault(o => o.Usuario.Login == login);
            }

            return operador;
        }

        public void Persistir()
        {
            this._contexto.SaveChanges();
        }
    }
}