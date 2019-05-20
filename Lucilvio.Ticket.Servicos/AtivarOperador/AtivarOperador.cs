using Lucilvio.Ticket.Servicos.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Servicos.AtivarOperador
{
    public class AtivarOperador : IServico<ComandoParaAtivarOperador>
    {
        private readonly IRepositorioParaAtivacaoDoOperador _repositorio;

        public AtivarOperador(IRepositorioParaAtivacaoDoOperador repositorio)
        {
            this._repositorio = repositorio;
        }

        public void Executar(ComandoParaAtivarOperador comando)
        {
            var operador = this._repositorio.PegarOperadorPeloId(comando.Id);

            if (operador == null)
                throw new OperadorNaoEncontrado();

            operador.Ativar();

            this._repositorio.Persistir(operador);
        }
    }
}
