using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lucilvio.Ticket.Infra.RepositoriosEf.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Chamados_ChamadoId",
                table: "Resposta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resposta",
                table: "Resposta");

            migrationBuilder.RenameTable(
                name: "Resposta",
                newName: "Respostas");

            migrationBuilder.RenameColumn(
                name: "ChamadoId",
                table: "Respostas",
                newName: "OperadorId");

            migrationBuilder.RenameIndex(
                name: "IX_Resposta_ChamadoId",
                table: "Respostas",
                newName: "IX_Respostas_OperadorId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Respostas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdChamado",
                table: "Respostas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Texto",
                table: "Respostas",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Respostas",
                table: "Respostas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_IdChamado",
                table: "Respostas",
                column: "IdChamado");

            migrationBuilder.AddForeignKey(
                name: "FK_Respostas_Chamados_IdChamado",
                table: "Respostas",
                column: "IdChamado",
                principalTable: "Chamados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Respostas_Operadores_OperadorId",
                table: "Respostas",
                column: "OperadorId",
                principalTable: "Operadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Respostas_Chamados_IdChamado",
                table: "Respostas");

            migrationBuilder.DropForeignKey(
                name: "FK_Respostas_Operadores_OperadorId",
                table: "Respostas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Respostas",
                table: "Respostas");

            migrationBuilder.DropIndex(
                name: "IX_Respostas_IdChamado",
                table: "Respostas");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Respostas");

            migrationBuilder.DropColumn(
                name: "IdChamado",
                table: "Respostas");

            migrationBuilder.DropColumn(
                name: "Texto",
                table: "Respostas");

            migrationBuilder.RenameTable(
                name: "Respostas",
                newName: "Resposta");

            migrationBuilder.RenameColumn(
                name: "OperadorId",
                table: "Resposta",
                newName: "ChamadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Respostas_OperadorId",
                table: "Resposta",
                newName: "IX_Resposta_ChamadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resposta",
                table: "Resposta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Chamados_ChamadoId",
                table: "Resposta",
                column: "ChamadoId",
                principalTable: "Chamados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
