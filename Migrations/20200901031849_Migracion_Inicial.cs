using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PensumProgresoAcademico.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Clave = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    HorasPracticas = table.Column<byte>(nullable: false),
                    HorasTeoricas = table.Column<byte>(nullable: false),
                    Creditos = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Clave);
                });

            migrationBuilder.CreateTable(
                name: "Pensum",
                columns: table => new
                {
                    PensumId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Carrera = table.Column<string>(nullable: true),
                    Duracion = table.Column<int>(nullable: false),
                    TituloOtorgar = table.Column<string>(nullable: true),
                    TotalMaterias = table.Column<int>(nullable: false),
                    PensumHorasPracticas = table.Column<int>(nullable: false),
                    PensumHorasTeoricas = table.Column<int>(nullable: false),
                    PensumCreditos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pensum", x => x.PensumId);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Matricula = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(nullable: true),
                    FechaIngreso = table.Column<DateTime>(nullable: false),
                    MateriasPendientes = table.Column<int>(nullable: false),
                    HorasPracticasPendientes = table.Column<int>(nullable: false),
                    HorasTeoricasPendientes = table.Column<int>(nullable: false),
                    CreditosPendientes = table.Column<int>(nullable: false),
                    PensumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Matricula);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Pensum_PensumId",
                        column: x => x.PensumId,
                        principalTable: "Pensum",
                        principalColumn: "PensumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PensumDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PensumId = table.Column<int>(nullable: false),
                    Clave = table.Column<string>(nullable: true),
                    Prerequisitos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PensumDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PensumDetalle_Materias_Clave",
                        column: x => x.Clave,
                        principalTable: "Materias",
                        principalColumn: "Clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PensumDetalle_Pensum_PensumId",
                        column: x => x.PensumId,
                        principalTable: "Pensum",
                        principalColumn: "PensumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    InscripcionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<int>(nullable: false),
                    CreditosSelccionados = table.Column<int>(nullable: false),
                    CantidadMateria = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    EstudianteMatricula = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.InscripcionId);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Estudiantes_EstudianteMatricula",
                        column: x => x.EstudianteMatricula,
                        principalTable: "Estudiantes",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InscripcionesDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InscripcionId = table.Column<int>(nullable: false),
                    Clave = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InscripcionesDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InscripcionesDetalle_Materias_Clave",
                        column: x => x.Clave,
                        principalTable: "Materias",
                        principalColumn: "Clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InscripcionesDetalle_Inscripciones_InscripcionId",
                        column: x => x.InscripcionId,
                        principalTable: "Inscripciones",
                        principalColumn: "InscripcionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_PensumId",
                table: "Estudiantes",
                column: "PensumId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EstudianteMatricula",
                table: "Inscripciones",
                column: "EstudianteMatricula");

            migrationBuilder.CreateIndex(
                name: "IX_InscripcionesDetalle_Clave",
                table: "InscripcionesDetalle",
                column: "Clave");

            migrationBuilder.CreateIndex(
                name: "IX_InscripcionesDetalle_InscripcionId",
                table: "InscripcionesDetalle",
                column: "InscripcionId");

            migrationBuilder.CreateIndex(
                name: "IX_PensumDetalle_Clave",
                table: "PensumDetalle",
                column: "Clave");

            migrationBuilder.CreateIndex(
                name: "IX_PensumDetalle_PensumId",
                table: "PensumDetalle",
                column: "PensumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InscripcionesDetalle");

            migrationBuilder.DropTable(
                name: "PensumDetalle");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Pensum");
        }
    }
}
