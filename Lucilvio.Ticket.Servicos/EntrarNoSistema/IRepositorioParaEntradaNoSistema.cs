using Lucilvio.Ticket.Dominio.Clientes;
using Lucilvio.Ticket.Dominio.Operadores;
using Lucilvio.Ticket.Dominio.Usuarios;

namespace Lucilvio.Ticket.Servicos.EntrarNoSistema
{
    public interface IRepositorioParaEntradaNoSistema : IRepositorio
    {
        Usuario PegarUsuarioPeloLoginESenha(string login, string senha);
        Cliente PegarClientePeloLogin(string login);
        Operador PegarOperadorPeloLogin(string login);
    }
}