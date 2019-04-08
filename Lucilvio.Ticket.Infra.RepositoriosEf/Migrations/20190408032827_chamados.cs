using Microsoft.EntityFrameworkCore.Migrations;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.Migrations
{
    public partial class chamados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Chamados",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Chamados",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Protocolo",
                table: "Chamados",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_ClienteId",
                table: "Chamados",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Clientes_ClienteId",
                table: "Chamados",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Clientes_ClienteId",
                table: "Chamados");

            migrationBuilder.DropIndex(
                name: "IX_Chamados_ClienteId",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "Protocolo",
                table: "Chamados");
        }
    }
}
