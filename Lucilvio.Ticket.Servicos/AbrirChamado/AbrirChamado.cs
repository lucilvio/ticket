using Lucilvio.Ticket.Dominio.Chamados;

namespace Lucilvio.Ticket.Servicos.AbrirChamado
{
    public class AbrirChamado : IServico<ComandoParaAbrirChamado>
    {
        private readonly IGeradorDeProtocolo _geradorDeProtocolo;
        private readonly IRepositorioParaAberturaDeChamado _repositorio;

        public AbrirChamado(IRepositorioParaAberturaDeChamado repositorio, IGeradorDeProtocolo geradorDeProtocolo)
        {
            this._repositorio = repositorio;
            this._geradorDeProtocolo = geradorDeProtocolo;
        }

        public void Executar(ComandoParaAbrirChamado comando)
        {
            var cliente = this._repositorio.PegarClientePeloLogin(comando.Cliente);

            if (cliente == null)
                throw new NenhumClienteEncontradoParaFazerAAberturaDoChamado();

            var ultimoProtocoloDeChamadoCriado = this._repositorio.PegarProtocoloDoUltimoChamadoAberto();
            var novoProtocolo = new Protocolo(this._geradorDeProtocolo.Gerar(ultimoProtocoloDeChamadoCriado)); 

            var novoChamado = cliente.AbrirChamado(novoProtocolo, comando.Descricao);

            this._repositorio.Persistir();
        }
    }
}