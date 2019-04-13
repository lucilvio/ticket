using System.Linq;
using Lucilvio.Ticket.Dominio.Clientes;
using Lucilvio.Ticket.Dominio.Operadores;
using Lucilvio.Ticket.Dominio.Usuarios;
using Lucilvio.Ticket.Servicos.EntrarNoSistema;
using Microsoft.EntityFrameworkCore;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaEntrarNoSistema
{
    public class RepositorioParaEntrarNoSistema : IRepositorioParaEntradaNoSistema
    {
        private readonly Contexto _contexto;

        public RepositorioParaEntrarNoSistema(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public Cliente PegarClientePeloLogin(string login)
        {
            return this._contexto.Clientes.FirstOrDefault(c => c.Usuario.Login == login);
        }

        public Operador PegarOperadorPeloLogin(string login)
        {
            return this._contexto.Operadores.FirstOrDefault(o => o.Usuario.Login == login);
        }

        public Usuario PegarUsuarioPeloLoginESenha(string login, string senha)
        {
            return this._contexto.Usuarios.FirstOrDefault(u => u.Login == login && u.Senha == senha);
        }
    }
}
