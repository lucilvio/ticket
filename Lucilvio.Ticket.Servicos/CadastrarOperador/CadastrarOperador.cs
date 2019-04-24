using Lucilvio.Ticket.Dominio.Operadores;
using System;
using System.Threading.Tasks;

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

            if (this.JaExisteUmOperadorCadastradoComOMesmoEmail(novoOperador.Email))
                throw new JaExisteUmOperadorCadastradoComOMesmoEmail();

            this._repositorio.AdicionarOperador(novoOperador);
            this._repositorio.Persistir();
        }

        private bool JaExisteUmOperadorCadastradoComOMesmoEmail(string email)
        {
            return this._repositorio.PegarOperadorPorEmail(email) != null;
        }
    }
}