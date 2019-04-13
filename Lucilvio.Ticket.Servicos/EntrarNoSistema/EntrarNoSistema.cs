using System.Threading.Tasks;
using Lucilvio.Ticket.Servicos.Comum;
using Lucilvio.Ticket.Servicos.Comum.ServicosExternos.Autenticacao;

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
            var usuario = this._repositorio.PegarUsuarioPeloLoginESenha(comando.Login, comando.Senha);

            if (usuario == null)
                throw new UsuarioOuSenhaInvalidos();
            
            await this._servicoDeSeguranca.Autenticar(new DadosDeAutenticacao(usuario.Nome, usuario.Login, usuario.Email, usuario.Perfil.ToString()));
        }
    }
}
