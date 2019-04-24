using Lucilvio.Ticket.Servicos.Comum;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Servicos.InativarOperador
{
    public class InativarOperador : IServico<ComandoParaInativarOperador>
    {
        private readonly IRepositorioParaInativacaoDoOperador _repositorio;

        public InativarOperador(IRepositorioParaInativacaoDoOperador repositorio)
        {
            this._repositorio = repositorio;
        }

        public void Executar(ComandoParaInativarOperador comando)
        {
            var operador = this._repositorio.PegarOperadorPeloId(comando.Id);

            if (operador == null)
                throw new OperadorNaoEncontrado();

            operador.Inativar();

            this._repositorio.Persistir();
        }
    }
}
