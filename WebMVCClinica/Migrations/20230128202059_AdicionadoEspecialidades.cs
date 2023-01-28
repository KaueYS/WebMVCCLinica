using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMVCClinica.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoEspecialidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PROFISSIONALESPECIALIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROFISSIONALESPECIALIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ESPECIALIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfisisonalEspecialidadeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESPECIALIDADES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ESPECIALIDADES_PROFISSIONALESPECIALIDADES_ProfisisonalEspecialidadeId",
                        column: x => x.ProfisisonalEspecialidadeId,
                        principalTable: "PROFISSIONALESPECIALIDADES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ESPECIALIDADES_ProfisisonalEspecialidadeId",
                table: "ESPECIALIDADES",
                column: "ProfisisonalEspecialidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ESPECIALIDADES");

            migrationBuilder.DropTable(
                name: "PROFISSIONALESPECIALIDADES");
        }
    }
}
