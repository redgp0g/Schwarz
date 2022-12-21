using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schwarz.Migrations
{
    public partial class ControleOleo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maquina",
                columns: table => new
                {
                    IDDMaquina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquina", x => x.IDDMaquina);
                });

            migrationBuilder.CreateTable(
                name: "CadastroOleo",
                columns: table => new
                {
                    IDCadastroOleo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDMaquina = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Litros = table.Column<double>(type: "float", nullable: false),
                    DiarioBordo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroOleo", x => x.IDCadastroOleo);
                    table.ForeignKey(
                        name: "FK_CadastroOleo_Maquina_IDMaquina",
                        column: x => x.IDMaquina,
                        principalTable: "Maquina",
                        principalColumn: "IDDMaquina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CadastroOleo_IDMaquina",
                table: "CadastroOleo",
                column: "IDMaquina");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CadastroOleo");

            migrationBuilder.DropTable(
                name: "Maquina");
        }
    }
}
