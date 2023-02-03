using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMVCClinica.Migrations
{
    /// <inheritdoc />
    public partial class AgendamentoUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfissionaId",
                table: "AGENDAMENTOS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfissionaId",
                table: "AGENDAMENTOS",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
