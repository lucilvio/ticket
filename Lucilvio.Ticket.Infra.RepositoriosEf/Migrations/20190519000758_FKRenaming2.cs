using Microsoft.EntityFrameworkCore.Migrations;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.Migrations
{
    public partial class FKRenaming2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContatosDeClientes_Clientes_DadosDoClienteId",
                table: "ContatosDeClientes");

            migrationBuilder.RenameColumn(
                name: "DadosDoClienteId",
                table: "ContatosDeClientes",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_ContatosDeClientes_DadosDoClienteId",
                table: "ContatosDeClientes",
                newName: "IX_ContatosDeClientes_ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContatosDeClientes_Clientes_ClienteId",
                table: "ContatosDeClientes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContatosDeClientes_Clientes_ClienteId",
                table: "ContatosDeClientes");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "ContatosDeClientes",
                newName: "DadosDoClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_ContatosDeClientes_ClienteId",
                table: "ContatosDeClientes",
                newName: "IX_ContatosDeClientes_DadosDoClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContatosDeClientes_Clientes_DadosDoClienteId",
                table: "ContatosDeClientes",
                column: "DadosDoClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
