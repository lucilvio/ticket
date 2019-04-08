namespace Lucilvio.Ticket.Servicos.ResponderChamado
{
    public class ResponderChamado : IServico<ComandoParaResponderChamado>
    {
        private readonly IRepositorioParaResponderChamado _repositorio;

        public ResponderChamado(IRepositorioParaResponderChamado repositorio)
        {
            this._repositorio = repositorio;
        }

        public void Executar(ComandoParaResponderChamado comando)
        {
            var operador = this._repositorio.PegarOperadorPeloLogin(comando.Operador);
            var chamado = this._repositorio.PegarChamadoPeloProtocolo(comando.Chamado);

            if (operador == null)
                throw new NenhumOperadorEncontradoParaRegistrarARespostaDoChamado();

            if (chamado == null)
                throw new NenhumChamadoEncontradoParaResponder();

            operador.ResponderAoChamado(chamado, comando.Resposta);

            this._repositorio.Persistir();
        }
    }
}