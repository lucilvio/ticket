using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.Migrations
{
    public partial class SeedAdmUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Ativo", "DataDoCadastro", "Email", "Login", "Nome", "Perfil", "Senha" },
                values: new object[] { 1, true, new DateTime(2019, 5, 18, 21, 16, 4, 666, DateTimeKind.Local).AddTicks(3248), "adm@ticket.com", "adm@ticket.com", "Administrador", 1, "123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
