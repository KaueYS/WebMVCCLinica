using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMVCClinica.Migrations
{
    /// <inheritdoc />
    public partial class AgendamentoUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AGENDAMENTOS_PROFISSIONAIS_ProfissionalId",
                table: "AGENDAMENTOS");

            migrationBuilder.AlterColumn<int>(
                name: "ProfissionalId",
                table: "AGENDAMENTOS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AGENDAMENTOS_PROFISSIONAIS_ProfissionalId",
                table: "AGENDAMENTOS",
                column: "ProfissionalId",
                principalTable: "PROFISSIONAIS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AGENDAMENTOS_PROFISSIONAIS_ProfissionalId",
                table: "AGENDAMENTOS");

            migrationBuilder.AlterColumn<int>(
                name: "ProfissionalId",
                table: "AGENDAMENTOS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AGENDAMENTOS_PROFISSIONAIS_ProfissionalId",
                table: "AGENDAMENTOS",
                column: "ProfissionalId",
                principalTable: "PROFISSIONAIS",
                principalColumn: "Id");
        }
    }
}
