using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoSYM.Migrations
{
    public partial class CreateRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicos",
                table: "Medicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consultorios",
                table: "Consultorios");

            migrationBuilder.RenameTable(
                name: "Medicos",
                newName: "medicos");

            migrationBuilder.RenameTable(
                name: "Consultorios",
                newName: "consultorios");

            migrationBuilder.AlterColumn<string>(
                name: "CRM",
                table: "medicos",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "medicos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_medicos",
                table: "medicos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_consultorios",
                table: "consultorios",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "medicosconsultorios",
                columns: table => new
                {
                    medicoId = table.Column<int>(type: "int", nullable: false),
                    consultorioId = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicosconsultorios", x => new { x.medicoId, x.consultorioId });
                    table.ForeignKey(
                        name: "FK_medicosconsultorios_consultorios_consultorioId",
                        column: x => x.consultorioId,
                        principalTable: "consultorios",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_medicosconsultorios_medicos_medicoId",
                        column: x => x.medicoId,
                        principalTable: "medicos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_medicosconsultorios_consultorioId",
                table: "medicosconsultorios",
                column: "consultorioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicosconsultorios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_medicos",
                table: "medicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_consultorios",
                table: "consultorios");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "medicos");

            migrationBuilder.RenameTable(
                name: "medicos",
                newName: "Medicos");

            migrationBuilder.RenameTable(
                name: "consultorios",
                newName: "Consultorios");

            migrationBuilder.AlterColumn<string>(
                name: "CRM",
                table: "Medicos",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicos",
                table: "Medicos",
                column: "CRM");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consultorios",
                table: "Consultorios",
                column: "ID");
        }
    }
}
