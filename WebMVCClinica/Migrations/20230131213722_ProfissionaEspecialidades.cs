using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMVCClinica.Migrations
{
    /// <inheritdoc />
    public partial class ProfissionaEspecialidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfissionalId",
                table: "PROFISSIONALESPECIALIDADES",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PROFISSIONALESPECIALIDADES_ProfissionalId",
                table: "PROFISSIONALESPECIALIDADES",
                column: "ProfissionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_PROFISSIONALESPECIALIDADES_PROFISSIONAIS_ProfissionalId",
                table: "PROFISSIONALESPECIALIDADES",
                column: "ProfissionalId",
                principalTable: "PROFISSIONAIS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PROFISSIONALESPECIALIDADES_PROFISSIONAIS_ProfissionalId",
                table: "PROFISSIONALESPECIALIDADES");

            migrationBuilder.DropIndex(
                name: "IX_PROFISSIONALESPECIALIDADES_ProfissionalId",
                table: "PROFISSIONALESPECIALIDADES");

            migrationBuilder.DropColumn(
                name: "ProfissionalId",
                table: "PROFISSIONALESPECIALIDADES");
        }
    }
}
