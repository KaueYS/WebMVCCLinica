using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMVCClinica.Migrations
{
    /// <inheritdoc />
    public partial class Especialidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ESPECIALIDADES_PROFISSIONALESPECIALIDADES_ProfisisonalEspecialidadeId",
                table: "ESPECIALIDADES");

            migrationBuilder.DropIndex(
                name: "IX_ESPECIALIDADES_ProfisisonalEspecialidadeId",
                table: "ESPECIALIDADES");

            migrationBuilder.DropColumn(
                name: "ProfisisonalEspecialidadeId",
                table: "ESPECIALIDADES");

            migrationBuilder.AddColumn<int>(
                name: "EspecialidadeId",
                table: "PROFISSIONALESPECIALIDADES",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PROFISSIONALESPECIALIDADES_EspecialidadeId",
                table: "PROFISSIONALESPECIALIDADES",
                column: "EspecialidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PROFISSIONALESPECIALIDADES_ESPECIALIDADES_EspecialidadeId",
                table: "PROFISSIONALESPECIALIDADES",
                column: "EspecialidadeId",
                principalTable: "ESPECIALIDADES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PROFISSIONALESPECIALIDADES_ESPECIALIDADES_EspecialidadeId",
                table: "PROFISSIONALESPECIALIDADES");

            migrationBuilder.DropIndex(
                name: "IX_PROFISSIONALESPECIALIDADES_EspecialidadeId",
                table: "PROFISSIONALESPECIALIDADES");

            migrationBuilder.DropColumn(
                name: "EspecialidadeId",
                table: "PROFISSIONALESPECIALIDADES");

            migrationBuilder.AddColumn<int>(
                name: "ProfisisonalEspecialidadeId",
                table: "ESPECIALIDADES",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ESPECIALIDADES_ProfisisonalEspecialidadeId",
                table: "ESPECIALIDADES",
                column: "ProfisisonalEspecialidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ESPECIALIDADES_PROFISSIONALESPECIALIDADES_ProfisisonalEspecialidadeId",
                table: "ESPECIALIDADES",
                column: "ProfisisonalEspecialidadeId",
                principalTable: "PROFISSIONALESPECIALIDADES",
                principalColumn: "Id");
        }
    }
}
