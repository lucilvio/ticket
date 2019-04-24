using Lucilvio.Ticket.Dominio.Chamados;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Servicos.AbrirChamado
{
    public class AbrirChamado : IServico<ComandoParaAbrirChamado>
    {
        private readonly IRepositorioParaAberturaDeChamado _repositorio;

        public AbrirChamado(IRepositorioParaAberturaDeChamado repositorio)
        {
            this._repositorio = repositorio;
        }

        public void Executar(ComandoParaAbrirChamado comando)
        {
            var cliente = this._repositorio.PegarClientePeloLogin(comando.Cliente);

            if (cliente == null)
                throw new NenhumClienteEncontradoParaFazerAAberturaDoChamado();

            var ultimoProtocoloDeChamadoCriado = this._repositorio.PegarProtocoloDoUltimoChamadoAberto();
            var geradorDeProtocolo = new Protocolo.Gerador(ultimoProtocoloDeChamadoCriado);

            var novoChamado = cliente.AbrirChamado(geradorDeProtocolo.NovoProtocolo(), comando.Descricao);

            this._repositorio.Persistir();
        }
    }
}