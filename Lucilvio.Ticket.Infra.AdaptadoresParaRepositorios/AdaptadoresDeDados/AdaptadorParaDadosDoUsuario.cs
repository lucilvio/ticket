using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Usuarios;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public static class AdaptadorParaDadosDoUsuario
    {
        public static DadosDoUsuario ParaDados(this Usuario usuario)
        {
            if (usuario == null)
                return null;

            return new DadosDoUsuario
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Ativo = usuario.Ativo,
                DataDoCadastro = usuario.DataDoCadastro,
                Login = usuario.Login,
                Perfil = (int)usuario.Perfil,
                Senha = usuario.Senha
            };
        }
    }
}