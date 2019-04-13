using Lucilvio.Ticket.Dominio.Usuarios;
using Lucilvio.Ticket.Servicos.EntrarNoSistema;
using System.Linq;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaEntrarNoSistema
{
    public class RepositorioParaEntrarNoSistema : IRepositorioParaEntradaNoSistema
    {
        private readonly Contexto _contexto;

        public RepositorioParaEntrarNoSistema(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public Usuario PegarUsuarioPeloLoginESenha(string usuario, string senha)
        {
            return this._contexto.Usuarios.FirstOrDefault(u => u.Login == usuario && u.Senha == senha);
        }
    }
}
