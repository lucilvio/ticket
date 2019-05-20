using System;
using Lucilvio.Ticket.Infra.Dados;
using Microsoft.EntityFrameworkCore;
using static Lucilvio.Ticket.Dominio.Usuarios.Usuario;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.Comum
{
    public class Seed
    {
        public static void Executar(ModelBuilder builder)
        {
            AdicionarUsuarioAdministrador(builder);
        }

        private static void AdicionarUsuarioAdministrador(ModelBuilder builder)
        {
            var administrador = new DadosDoUsuario
            {
                Id = 1,
                Nome = "Administrador",
                Login = "adm@ticket.com",
                Senha = "123456",
                Ativo = true, DataDoCadastro = DateTime.Now,
                Email = "adm@ticket.com",
                Perfil = (int)PerfilDoUsuario.Administrador
            };

            builder.Entity<DadosDoUsuario>().HasData(administrador);
        }
    }
}
