using Lucilvio.Ticket.Servicos.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Servicos.SairDoSistema
{
    public class SairDoSistema : IServico<ComandoParaSairDoSistema>
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
