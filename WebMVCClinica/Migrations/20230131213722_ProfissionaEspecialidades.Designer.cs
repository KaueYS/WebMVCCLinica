﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebMVCClinica.Data.Context;

#nullable disable

namespace WebMVCClinica.Migrations
{
    [DbContext(typeof(AgendarPacienteContext))]
    [Migration("20230131213722_ProfissionaEspecialidades")]
    partial class ProfissionaEspecialidades
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebMVCClinica.Models.Agendamento", b =>
                {
                    b.Property<int>("AgendamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgendamentoId"));

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Termino")
                        .HasColumnType("datetime2");

                    b.HasKey("AgendamentoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("AGENDAMENTOS");
                });

            modelBuilder.Entity("WebMVCClinica.Models.Especialidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfisisonalEspecialidadeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfisisonalEspecialidadeId");

                    b.ToTable("ESPECIALIDADES");
                });

            modelBuilder.Entity("WebMVCClinica.Models.Paciente", b =>
                {
                    b.Property<int>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PacienteId"));

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PacienteId");

                    b.ToTable("PACIENTES");
                });

            modelBuilder.Entity("WebMVCClinica.Models.ProfisisonalEspecialidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProfissionalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("PROFISSIONALESPECIALIDADES");
                });

            modelBuilder.Entity("WebMVCClinica.Models.Profissional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PROFISSIONAIS");
                });

            modelBuilder.Entity("WebMVCClinica.Models.ProfissionalParametro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfissionalId")
                        .HasColumnType("int");

                    b.Property<string>("Valor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("PROFISSIONAISPARAMETROS");
                });

            modelBuilder.Entity("WebMVCClinica.Models.Agendamento", b =>
                {
                    b.HasOne("WebMVCClinica.Models.Paciente", "Paciente")
                        .WithMany("Agendamentos")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("WebMVCClinica.Models.Especialidade", b =>
                {
                    b.HasOne("WebMVCClinica.Models.ProfisisonalEspecialidade", null)
                        .WithMany("Especialidades")
                        .HasForeignKey("ProfisisonalEspecialidadeId");
                });

            modelBuilder.Entity("WebMVCClinica.Models.ProfisisonalEspecialidade", b =>
                {
                    b.HasOne("WebMVCClinica.Models.Profissional", "Profissional")
                        .WithMany()
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("WebMVCClinica.Models.ProfissionalParametro", b =>
                {
                    b.HasOne("WebMVCClinica.Models.Profissional", "Profissional")
                        .WithMany("ProfissionalParametro")
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("WebMVCClinica.Models.Paciente", b =>
                {
                    b.Navigation("Agendamentos");
                });

            modelBuilder.Entity("WebMVCClinica.Models.ProfisisonalEspecialidade", b =>
                {
                    b.Navigation("Especialidades");
                });

            modelBuilder.Entity("WebMVCClinica.Models.Profissional", b =>
                {
                    b.Navigation("ProfissionalParametro");
                });
#pragma warning restore 612, 618
        }
    }
}
