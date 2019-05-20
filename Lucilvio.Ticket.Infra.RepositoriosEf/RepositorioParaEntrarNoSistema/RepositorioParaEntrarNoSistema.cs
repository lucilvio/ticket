using System.Linq;
using Lucilvio.Ticket.Dominio.Usuarios;
using Lucilvio.Ticket.Servicos.EntrarNoSistema;
using Lucilvio.Ticket.Infra.RepositoriosEf.Comum;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaEntrarNoSistema
{
    public class RepositorioParaEntrarNoSistema : IRepositorioParaEntradaNoSistema
    {
        private readonly Contexto _contexto;
        private readonly IAdaptadorDoRepositorioParaEntradaNoSistema _adaptador;

        public RepositorioParaEntrarNoSistema(Contexto contexto, IAdaptadorDoRepositorioParaEntradaNoSistema adaptador)
        {
            this._contexto = contexto;
            this._adaptador = adaptador;
        }

        public Usuario PegarUsuarioPeloLoginESenha(string login, string senha)
        {
            var usuario = this._contexto.Usuarios.FirstOrDefault(u => u.Login == login && u.Senha == senha);
            return this._adaptador.AdaptarUsuarioParaEntidade(usuario);
        }
    }
}