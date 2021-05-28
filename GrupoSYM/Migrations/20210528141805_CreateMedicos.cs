using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoSYM.Migrations
{
    public partial class CreateMedicos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    CRM = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Nome = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Telefone = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ValorConsulta = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.CRM);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}
