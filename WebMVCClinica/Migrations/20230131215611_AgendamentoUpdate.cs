using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMVCClinica.Migrations
{
    /// <inheritdoc />
    public partial class AgendamentoUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfissionaId",
                table: "AGENDAMENTOS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfissionalId",
                table: "AGENDAMENTOS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AGENDAMENTOS_ProfissionalId",
                table: "AGENDAMENTOS",
                column: "ProfissionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_AGENDAMENTOS_PROFISSIONAIS_ProfissionalId",
                table: "AGENDAMENTOS",
                column: "ProfissionalId",
                principalTable: "PROFISSIONAIS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AGENDAMENTOS_PROFISSIONAIS_ProfissionalId",
                table: "AGENDAMENTOS");

            migrationBuilder.DropIndex(
                name: "IX_AGENDAMENTOS_ProfissionalId",
                table: "AGENDAMENTOS");

            migrationBuilder.DropColumn(
                name: "ProfissionaId",
                table: "AGENDAMENTOS");

            migrationBuilder.DropColumn(
                name: "ProfissionalId",
                table: "AGENDAMENTOS");
        }
    }
}
