using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Usuarios;
using System;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public static class AdaptadorParaUsuario
    {
        public static Usuario ParaEntidade(this DadosDoUsuario dados)
        {
            if (dados == null)
                return null;

            var tipoDoDestino = typeof(Usuario);
            var destino = (Usuario)Activator.CreateInstance(tipoDoDestino, true);

            tipoDoDestino.GetProperty("Id").SetValue(destino, dados.Id);
            tipoDoDestino.GetProperty("Nome").SetValue(destino, dados.Nome);
            tipoDoDestino.GetProperty("Login").SetValue(destino, dados.Login);
            tipoDoDestino.GetProperty("Perfil").SetValue(destino, dados.Perfil);
            tipoDoDestino.GetProperty("Ativo").SetValue(destino, dados.Ativo);
            tipoDoDestino.GetProperty("DataDoCadastro").SetValue(destino, dados.DataDoCadastro);
            tipoDoDestino.GetProperty("Email").SetValue(destino, dados.Email);
            tipoDoDestino.GetProperty("Senha").SetValue(destino, dados.Senha);

            return destino;
        }
    }
}