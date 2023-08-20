using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMVCClinica.Migrations
{
    /// <inheritdoc />
    public partial class Versao00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ESPECIALIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESPECIALIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTES",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTES", x => x.PacienteId);
                });

            migrationBuilder.CreateTable(
                name: "PROFISSIONAIS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROFISSIONAIS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AGENDAMENTOS",
                columns: table => new
                {
                    AgendamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Termino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfissionalId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENDAMENTOS", x => x.AgendamentoId);
                    table.ForeignKey(
                        name: "FK_AGENDAMENTOS_PACIENTES_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "PACIENTES",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AGENDAMENTOS_PROFISSIONAIS_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "PROFISSIONAIS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PROFISSIONAISPARAMETROS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfissionalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROFISSIONAISPARAMETROS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PROFISSIONAISPARAMETROS_PROFISSIONAIS_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "PROFISSIONAIS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PROFISSIONALESPECIALIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfissionalId = table.Column<int>(type: "int", nullable: false),
                    EspecialidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROFISSIONALESPECIALIDADES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PROFISSIONALESPECIALIDADES_ESPECIALIDADES_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "ESPECIALIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROFISSIONALESPECIALIDADES_PROFISSIONAIS_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "PROFISSIONAIS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AGENDAMENTOS_PacienteId",
                table: "AGENDAMENTOS",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AGENDAMENTOS_ProfissionalId",
                table: "AGENDAMENTOS",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_PROFISSIONAISPARAMETROS_ProfissionalId",
                table: "PROFISSIONAISPARAMETROS",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_PROFISSIONALESPECIALIDADES_EspecialidadeId",
                table: "PROFISSIONALESPECIALIDADES",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_PROFISSIONALESPECIALIDADES_ProfissionalId",
                table: "PROFISSIONALESPECIALIDADES",
                column: "ProfissionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AGENDAMENTOS");

            migrationBuilder.DropTable(
                name: "PROFISSIONAISPARAMETROS");

            migrationBuilder.DropTable(
                name: "PROFISSIONALESPECIALIDADES");

            migrationBuilder.DropTable(
                name: "PACIENTES");

            migrationBuilder.DropTable(
                name: "ESPECIALIDADES");

            migrationBuilder.DropTable(
                name: "PROFISSIONAIS");
        }
    }
}
