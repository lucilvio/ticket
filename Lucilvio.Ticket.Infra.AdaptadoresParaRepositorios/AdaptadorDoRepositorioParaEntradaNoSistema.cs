using System;
using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Usuarios;
using Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaEntrarNoSistema;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public class AdaptadorDoRepositorioParaEntradaNoSistema : IAdaptadorDoRepositorioParaEntradaNoSistema
    {
        public Usuario AdaptarUsuarioParaEntidade(DadosDoUsuario dados) => dados.ParaEntidade();
    }
}