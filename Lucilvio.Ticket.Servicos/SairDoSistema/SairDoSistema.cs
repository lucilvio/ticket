using System.Threading.Tasks;
using Lucilvio.Ticket.Servicos.Comum.ServicosExternos.Autenticacao;

namespace Lucilvio.Ticket.Servicos.SairDoSistema
{
    public class SairDoSistema : IServicoAsync<ComandoParaSairDoSistema>
    {
        private readonly IServicoDeAutenticacao _servicoDeAutenticacao;

        public SairDoSistema(IServicoDeAutenticacao servicoDeAutenticacao)
        {
            this._servicoDeAutenticacao = servicoDeAutenticacao;
        }

        public async Task Executar(ComandoParaSairDoSistema comando)
        {
            await this._servicoDeAutenticacao.RevogarAutenticacao();
        }
    }
}
