using Lucilvio.Ticket.Dominio.Usuarios;

namespace Lucilvio.Ticket.Servicos.EntrarNoSistema
{
    public interface IRepositorioParaEntradaNoSistema
    {
        Usuario PegarUsuarioPeloLoginESenha(string usuario, string senha);
    }
}