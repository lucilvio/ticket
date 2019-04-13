using Lucilvio.Ticket.Dominio.Usuarios;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Servicos.Comum
{
    public interface IServicoDeAutenticacao
    {
        Task AutenticarUsuario(Usuario usuario);
        Task RevogarAutenticacao();
    }
}