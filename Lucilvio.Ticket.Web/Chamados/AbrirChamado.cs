using System;
using Lucilvio.Ticket.Testes;

namespace Lucilvio.Ticket.Web.Chamados
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
            var cliente = this._repositorio.PegarClientePeloLogin("login");
            var ultimoProtocoloDeChamadoCriado = this._repositorio.PegarProtocoloDoUltimoChamadoAberto();

            var geradorDeProtocolo = new Protocolo.Gerador(ultimoProtocoloDeChamadoCriado);

            var novoChamado = cliente.AbrirChamado(geradorDeProtocolo.NovoProtocolo(), comando.Descricao, new SemNotificacao());

            this._repositorio.AbrirChamado(novoChamado);
        }
    }
}