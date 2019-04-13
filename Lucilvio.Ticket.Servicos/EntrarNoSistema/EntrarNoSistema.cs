using Lucilvio.Ticket.Servicos.Comum;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Servicos.EntrarNoSistema
{
    public class EntrarNoSistema : IServico<ComandoParaEntrarNoSistema>
    {
        private readonly IServicoDeAutenticacao _servicoDeSeguranca;
        private readonly IRepositorioParaEntradaNoSistema _repositorio;

        public EntrarNoSistema(IRepositorioParaEntradaNoSistema repositorio, IServicoDeAutenticacao servicoDeSeguranca)
        {
            this._repositorio = repositorio;
            this._servicoDeSeguranca = servicoDeSeguranca;
        }

        public async Task Executar(ComandoParaEntrarNoSistema comando)
        {
            var usuario = this._repositorio.PegarUsuarioPeloLoginESenha(comando.Usuario, comando.Senha);

            if (usuario == null)
                throw new UsuarioOuSenhaInvalidos();

            await this._servicoDeSeguranca.AutenticarUsuario(usuario);
        }
    }
}
