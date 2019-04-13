using System.Threading.Tasks;
using Lucilvio.Ticket.Servicos.EntrarNoSistema;
using Lucilvio.Ticket.Servicos.Comum.ServicosExternos.Autenticacao;
using Lucilvio.Ticket.Servicos.Comum;

namespace Lucilvio.Ticket.Servicos.EntrarNoSistemaComoCliente
{
    public class EntrarNoSistemaComoCliente : IServico<ComandoParaEntrarNoSistemaComoCliente>
    {
        private readonly IServicoDeAutenticacao _servicoDeAutenticacao;
        private readonly IRepositorioParaEntradaNoSistemaComoCliente _repositorio;

        public EntrarNoSistemaComoCliente(IRepositorioParaEntradaNoSistemaComoCliente repositorio, IServicoDeAutenticacao servicoDeAutenticacao)
        {
            this._repositorio = repositorio;
            this._servicoDeAutenticacao = servicoDeAutenticacao;
        }

        public async Task Executar(ComandoParaEntrarNoSistemaComoCliente comando)
        {
            var cliente = this._repositorio.PegarClientePeloLoginESenha(comando.Login, comando.Senha);

            if (cliente == null)
                throw new UsuarioOuSenhaInvalidos();

            await this._servicoDeAutenticacao.Autenticar(new DadosDeAutenticacao(cliente.Nome, cliente.Login, cliente.Email, cliente.Perfil.ToString()));
        }
    }
}