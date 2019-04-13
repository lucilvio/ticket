using System.Threading.Tasks;
using Lucilvio.Ticket.Dominio.Usuarios;

namespace Lucilvio.Ticket.Servicos.Comum.ServicosExternos.Autenticacao
{
    public interface IServicoDeAutenticacao
    {
        Task Autenticar(DadosDeAutenticacao usuario);
        Task RevogarAutenticacao();
    }
}