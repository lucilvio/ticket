using Lucilvio.Ticket.Dominio.Usuarios;
using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Infra.RepositoriosEf.Comum;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaEntrarNoSistema
{
    public interface IAdaptadorDoRepositorioParaEntradaNoSistema : IAdaptador
    {
        Usuario AdaptarUsuarioParaEntidade(DadosDoUsuario usuario);
    }
}