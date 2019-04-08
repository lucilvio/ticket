using Microsoft.EntityFrameworkCore.Migrations;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.Migrations
{
    public partial class novo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Respostas_Chamados_IdChamado",
                table: "Respostas");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Usuarios",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdChamado",
                table: "Respostas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Respostas_Chamados_IdChamado",
                table: "Respostas",
                column: "IdChamado",
                principalTable: "Chamados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Respostas_Chamados_IdChamado",
                table: "Respostas");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "IdChamado",
                table: "Respostas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Respostas_Chamados_IdChamado",
                table: "Respostas",
                column: "IdChamado",
                principalTable: "Chamados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
