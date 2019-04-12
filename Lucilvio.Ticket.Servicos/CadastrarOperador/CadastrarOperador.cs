using Lucilvio.Ticket.Dominio.Operadores;

namespace Lucilvio.Ticket.Servicos.CadastrarOperador
{
    public class CadastrarOperador : IServico<ComandoParaCadastrarOperador>
    {
        private readonly IRepositorioParaCadastroDeOperador _repositorio;

        public CadastrarOperador(IRepositorioParaCadastroDeOperador repositorio)
        {
            this._repositorio = repositorio;
        }

        public void Executar(ComandoParaCadastrarOperador comando)
        {
            var novoOperador = new Operador(comando.Nome, comando.Email, comando.Senha);

            this._repositorio.AdicionarOperador(novoOperador);
            this._repositorio.Persistir();
        }
    }
}