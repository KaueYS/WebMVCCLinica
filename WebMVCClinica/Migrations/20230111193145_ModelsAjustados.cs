using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMVCClinica.Migrations
{
    /// <inheritdoc />
    public partial class ModelsAjustados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AGENDAMENTOS_PacienteId",
                table: "AGENDAMENTOS",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_AGENDAMENTOS_PACIENTES_PacienteId",
                table: "AGENDAMENTOS",
                column: "PacienteId",
                principalTable: "PACIENTES",
                principalColumn: "PacienteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AGENDAMENTOS_PACIENTES_PacienteId",
                table: "AGENDAMENTOS");

            migrationBuilder.DropIndex(
                name: "IX_AGENDAMENTOS_PacienteId",
                table: "AGENDAMENTOS");
        }
    }
}
