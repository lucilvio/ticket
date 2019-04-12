using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Clientes;
using Lucilvio.Ticket.Servicos.AbrirChamado;
using System.Linq;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaAberturaDeChamado
{
    public class RepositorioParaAberturaDeChamado : IRepositorioParaAberturaDeChamado
    {
        private readonly Contexto _contexto;

        public RepositorioParaAberturaDeChamado(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public Cliente PegarClientePeloLogin(string login)
        {
            Cliente clienteDeTeste = this._contexto.Clientes.FirstOrDefault(c => c.Usuario.Login == login);

            if (clienteDeTeste == null)
            {
                this._contexto.Clientes.Add(new Cliente("teste", "teste", "123456"));
                this._contexto.SaveChanges();

                clienteDeTeste = this._contexto.Clientes.FirstOrDefault(c => c.Usuario.Login == login);
            }

            return clienteDeTeste;
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
