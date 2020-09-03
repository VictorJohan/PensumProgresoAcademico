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

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "HUM-111", (byte)4, "LENGUA ESPAÑOLA Y TECNICA DE EXPRESION I", (byte)0, (byte)4 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "CNT-227", (byte)3, "CONTABILIDAD APLICADA", (byte)2, (byte)2 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-804", (byte)1, "LAB. PROGRAMACION APLICADA I", (byte)2, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-803", (byte)2, "PROGRAMACION APLICADA I", (byte)0, (byte)2 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "MAT-221", (byte)4, "ESTADISTICA GENERAL II", (byte)2, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "PSI-122", (byte)3, "INTRODUCCION A LA PSICOLOGIA", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "IC-433", (byte)3, "INGENIERIA ECONOMICA", (byte)2, (byte)2 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-802", (byte)3, "ORG. Y ADM. DE SISTEMAS", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-801", (byte)3, "DISEÑO DE SISTEMAS", (byte)2, (byte)2 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-901", (byte)3, "SISTEMAS OPERATIVOS II", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-706", (byte)2, "PROYECTO APLICADO", (byte)4, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "CNT-215", (byte)3, "CONTABILIDAD GENERAL I", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-705", (byte)2, "MATENIMIENTO DE HARDWARE", (byte)2, (byte)1 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-704", (byte)1, "LAB. BASE DE DATOS", (byte)2, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-703", (byte)3, "BASE DE DATOS", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-702", (byte)1, "LABORATORIO SISTEMAS OPERATIVOS I", (byte)2, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-701", (byte)3, "SISTEMAS OPERATIVOS I", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "CS-137", (byte)3, "METODOLOGIA DE INVESTIGACION CIENTIFICA I", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ECO-235", (byte)3, "ECOLOGIA Y PRESERVACION DEL MEDIO AMBIENTE", (byte)2, (byte)2 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "CNT-216", (byte)1, "LABORATORIO DE CONTABILIDAD GENERAL I", (byte)2, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-902", (byte)1, "LABORATORIO SISTEMAS OPERATIVOS II", (byte)2, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "MAT-225", (byte)3, "PROGRAMACION LINEAL PARA INGENIERIA", (byte)2, (byte)2 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-903", (byte)4, "LENGUAJE DE PROGRAMACION", (byte)2, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "CS-232", (byte)2, "MET. INVESTIGACION CIENTIF. II", (byte)0, (byte)2 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "HUM-117", (byte)2, "ETICA PARA INGENIERIA DE SISTEMAS", (byte)0, (byte)2 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-116", (byte)3, "MERCADEO DE SOFTWARE", (byte)2, (byte)2 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-115", (byte)3, "ADM. DE CENTROS DE COMPUTOS", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-114", (byte)1, "LAB. PROGRAMACION APLICADA III", (byte)2, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-113", (byte)2, "PROGRAMACION APLICADA III", (byte)0, (byte)2 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-112", (byte)4, "INGENIERIA DE SOFTWARE", (byte)2, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-111", (byte)3, "SIMULACION DIGITAL", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-106", (byte)1, "LAB. METODOS NUMERICOS", (byte)2, (byte)1 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-105", (byte)3, "METODOS NUMERICOS", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ADM-429", (byte)4, "PLANIFICACION ESTRATEGICA", (byte)0, (byte)4 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-104", (byte)2, "ELECTIVA II", (byte)2, (byte)1 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-103", (byte)3, "TECNOLOGIAS DE INFORMACION", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ADM-321", (byte)3, "TEORIA DE DECISIONES", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-102", (byte)1, "LAB. PROGRAM. APLICADA II", (byte)2, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-101", (byte)2, "PROGRAMACION APLICADA II", (byte)0, (byte)2 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-906", (byte)2, "ELECTIVA I", (byte)2, (byte)1 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-905", (byte)1, "LAB. TELEPROCESO Y REDES II", (byte)2, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-904", (byte)3, "TELEPROCESO Y REDES II", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-777", (byte)0, "PASANTIA I", (byte)0, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-011", (byte)0, "PASANTIA II", (byte)0, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "HUM-301", (byte)2, "DOCTRINA SOCIAL DE LA IGLESIA", (byte)0, (byte)2 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-606", (byte)3, "PROGRAMACION III", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "MAT-136", (byte)5, "CALCULO I", (byte)2, (byte)4 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "HUM-291", (byte)2, "EDUCACION EN VALORES", (byte)0, (byte)2 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "FIS-135", (byte)1, "LABORATORIO FISICA I", (byte)2, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "FIS-134", (byte)5, "FISICA I", (byte)2, (byte)4 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-202", (byte)1, "LABORATORIO INTRODUCCION A LA INGENIERIA DE SISTEMAS", (byte)2, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-201", (byte)2, "INTRODUCCION A LA INGENIERIA DE SISTEMAS", (byte)0, (byte)2 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ING-221", (byte)4, "INGLES ELEMENTAL II", (byte)2, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "FIS-128", (byte)1, "LABORATORIO FISICA BASICA", (byte)2, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ING-315", (byte)4, "INGLES INTERMEDIO I", (byte)2, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "FIS-127", (byte)4, "FISICA BASICA", (byte)2, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "HUM-121", (byte)4, "LENGUA ESPAÑOLA Y TECNICA EXPRESION II", (byte)0, (byte)4 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "CS-126", (byte)3, "HISTORIA SOCIAL DOMINICANA", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "QMA-118", (byte)1, "LABORATORIO QUIMICA I", (byte)2, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "QMA-117", (byte)3, "QUIMICA I", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ORI-116", (byte)1, "ORIENTACION ACADEMICA", (byte)0, (byte)1 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "MAT-112", (byte)4, "MATEMATICA BASICA I", (byte)2, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ING-111", (byte)4, "INGLES ELEMENTAL I", (byte)2, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "CS-115", (byte)2, "INTRODUCCION AL ESTUDIO DE LAS CIENCIAS SOCIALES", (byte)0, (byte)2 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "MAT-125", (byte)4, "PRECALCULO", (byte)2, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-301", (byte)2, "TECNICA DE PROGRAMACION", (byte)0, (byte)2 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-302", (byte)1, "LABORATORIO TECNICA DE PROGRAMACION", (byte)2, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ORI-127", (byte)1, "ACTIVIDAD CO-CURRICULAR", (byte)2, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-605", (byte)3, "ESTRUCTURA DE DATOS", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ADM-311", (byte)3, "ADMINISTRACION DE EMPRESAS I", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-604", (byte)2, "ARQUITECTURA DEL COMPUTADOR", (byte)0, (byte)2 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-603", (byte)1, "LAB. TELEPROCESO Y REDES I", (byte)2, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-602", (byte)3, "TELEPROCESO Y REDES I", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-601", (byte)3, "ANALISIS DE SISTEMAS", (byte)2, (byte)2 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "HUM-300", (byte)2, "BIOETICA", (byte)0, (byte)2 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "EC-131", (byte)3, "INTRODUCCION A LA ECONOMIA", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-503", (byte)1, "LABORATORIO DE PROGRAMACION II", (byte)2, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-502", (byte)3, "PROGRAMACION II", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "MAT-211", (byte)4, "ESTADISTICA GENERAL I", (byte)2, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-501", (byte)4, "ELECTRONICA APLICADA", (byte)2, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "MAT-229", (byte)5, "CALCULO III", (byte)2, (byte)4 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-402", (byte)1, "LABORATORIO PROGRAMACION I", (byte)2, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-401", (byte)3, "PROGRAMACION I", (byte)0, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ING-424", (byte)4, "INGLES PARA SISTEMAS", (byte)2, (byte)3 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "MAT-215", (byte)5, "CALCULO II", (byte)2, (byte)4 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "FIS-219", (byte)1, "LABORATORIO FISICA II", (byte)2, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "FIS-218", (byte)5, "FISICA II", (byte)2, (byte)4 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-607", (byte)1, "LAB. PROGRAMACION III", (byte)2, (byte)0 });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Clave", "Creditos", "Descripcion", "HorasPracticas", "HorasTeoricas" },
                values: new object[] { "ISC-121", (byte)6, "TESIS DE GRADO O CURSO AVANZADO", (byte)6, (byte)3 });

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
