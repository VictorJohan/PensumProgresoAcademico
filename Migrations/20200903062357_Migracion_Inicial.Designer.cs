﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PensumProgresoAcademico.DAL;

namespace PensumProgresoAcademico.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200903062357_Migracion_Inicial")]
    partial class Migracion_Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("PensumProgresoAcademico.Entidades.Estudiantes", b =>
                {
                    b.Property<int>("Matricula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CreditosPendientes")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("TEXT");

                    b.Property<int>("HorasPracticasPendientes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HorasTeoricasPendientes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MateriasPendientes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<int>("PensumId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Matricula");

                    b.HasIndex("PensumId");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("PensumProgresoAcademico.Entidades.Inscripciones", b =>
                {
                    b.Property<int>("InscripcionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadMateria")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CreditosSelccionados")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EstudianteMatricula")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("Matricula")
                        .HasColumnType("INTEGER");

                    b.HasKey("InscripcionId");

                    b.HasIndex("EstudianteMatricula");

                    b.ToTable("Inscripciones");
                });

            modelBuilder.Entity("PensumProgresoAcademico.Entidades.InscripcionesDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Clave")
                        .HasColumnType("TEXT");

                    b.Property<int>("InscripcionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Clave");

                    b.HasIndex("InscripcionId");

                    b.ToTable("InscripcionesDetalle");
                });

            modelBuilder.Entity("PensumProgresoAcademico.Entidades.Materias", b =>
                {
                    b.Property<string>("Clave")
                        .HasColumnType("TEXT");

                    b.Property<byte>("Creditos")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<byte>("HorasPracticas")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("HorasTeoricas")
                        .HasColumnType("INTEGER");

                    b.HasKey("Clave");

                    b.ToTable("Materias");

                    b.HasData(
                        new
                        {
                            Clave = "HUM-111",
                            Creditos = (byte)4,
                            Descripcion = "LENGUA ESPAÑOLA Y TECNICA DE EXPRESION I",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)4
                        },
                        new
                        {
                            Clave = "CS-115",
                            Creditos = (byte)2,
                            Descripcion = "INTRODUCCION AL ESTUDIO DE LAS CIENCIAS SOCIALES",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)2
                        },
                        new
                        {
                            Clave = "ING-111",
                            Creditos = (byte)4,
                            Descripcion = "INGLES ELEMENTAL I",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "MAT-112",
                            Creditos = (byte)4,
                            Descripcion = "MATEMATICA BASICA I",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ORI-116",
                            Creditos = (byte)1,
                            Descripcion = "ORIENTACION ACADEMICA",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)1
                        },
                        new
                        {
                            Clave = "QMA-117",
                            Creditos = (byte)3,
                            Descripcion = "QUIMICA I",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "QMA-118",
                            Creditos = (byte)1,
                            Descripcion = "LABORATORIO QUIMICA I",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "CS-126",
                            Creditos = (byte)3,
                            Descripcion = "HISTORIA SOCIAL DOMINICANA",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "HUM-121",
                            Creditos = (byte)4,
                            Descripcion = "LENGUA ESPAÑOLA Y TECNICA EXPRESION II",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)4
                        },
                        new
                        {
                            Clave = "MAT-125",
                            Creditos = (byte)4,
                            Descripcion = "PRECALCULO",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "FIS-127",
                            Creditos = (byte)4,
                            Descripcion = "FISICA BASICA",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "FIS-128",
                            Creditos = (byte)1,
                            Descripcion = "LABORATORIO FISICA BASICA",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "ING-221",
                            Creditos = (byte)4,
                            Descripcion = "INGLES ELEMENTAL II",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-201",
                            Creditos = (byte)2,
                            Descripcion = "INTRODUCCION A LA INGENIERIA DE SISTEMAS",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)2
                        },
                        new
                        {
                            Clave = "ISC-202",
                            Creditos = (byte)1,
                            Descripcion = "LABORATORIO INTRODUCCION A LA INGENIERIA DE SISTEMAS",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "FIS-134",
                            Creditos = (byte)5,
                            Descripcion = "FISICA I",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)4
                        },
                        new
                        {
                            Clave = "FIS-135",
                            Creditos = (byte)1,
                            Descripcion = "LABORATORIO FISICA I",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "HUM-291",
                            Creditos = (byte)2,
                            Descripcion = "EDUCACION EN VALORES",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)2
                        },
                        new
                        {
                            Clave = "MAT-136",
                            Creditos = (byte)5,
                            Descripcion = "CALCULO I",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)4
                        },
                        new
                        {
                            Clave = "ING-315",
                            Creditos = (byte)4,
                            Descripcion = "INGLES INTERMEDIO I",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-301",
                            Creditos = (byte)2,
                            Descripcion = "TECNICA DE PROGRAMACION",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)2
                        },
                        new
                        {
                            Clave = "ISC-302",
                            Creditos = (byte)1,
                            Descripcion = "LABORATORIO TECNICA DE PROGRAMACION",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "ORI-127",
                            Creditos = (byte)1,
                            Descripcion = "ACTIVIDAD CO-CURRICULAR",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "FIS-218",
                            Creditos = (byte)5,
                            Descripcion = "FISICA II",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)4
                        },
                        new
                        {
                            Clave = "FIS-219",
                            Creditos = (byte)1,
                            Descripcion = "LABORATORIO FISICA II",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "MAT-215",
                            Creditos = (byte)5,
                            Descripcion = "CALCULO II",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)4
                        },
                        new
                        {
                            Clave = "ING-424",
                            Creditos = (byte)4,
                            Descripcion = "INGLES PARA SISTEMAS",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-401",
                            Creditos = (byte)3,
                            Descripcion = "PROGRAMACION I",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-402",
                            Creditos = (byte)1,
                            Descripcion = "LABORATORIO PROGRAMACION I",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "MAT-229",
                            Creditos = (byte)5,
                            Descripcion = "CALCULO III",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)4
                        },
                        new
                        {
                            Clave = "ISC-501",
                            Creditos = (byte)4,
                            Descripcion = "ELECTRONICA APLICADA",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "MAT-211",
                            Creditos = (byte)4,
                            Descripcion = "ESTADISTICA GENERAL I",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-502",
                            Creditos = (byte)3,
                            Descripcion = "PROGRAMACION II",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-503",
                            Creditos = (byte)1,
                            Descripcion = "LABORATORIO DE PROGRAMACION II",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "EC-131",
                            Creditos = (byte)3,
                            Descripcion = "INTRODUCCION A LA ECONOMIA",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "HUM-300",
                            Creditos = (byte)2,
                            Descripcion = "BIOETICA",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)2
                        },
                        new
                        {
                            Clave = "ISC-601",
                            Creditos = (byte)3,
                            Descripcion = "ANALISIS DE SISTEMAS",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)2
                        },
                        new
                        {
                            Clave = "ISC-602",
                            Creditos = (byte)3,
                            Descripcion = "TELEPROCESO Y REDES I",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-603",
                            Creditos = (byte)1,
                            Descripcion = "LAB. TELEPROCESO Y REDES I",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "ISC-604",
                            Creditos = (byte)2,
                            Descripcion = "ARQUITECTURA DEL COMPUTADOR",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)2
                        },
                        new
                        {
                            Clave = "ADM-311",
                            Creditos = (byte)3,
                            Descripcion = "ADMINISTRACION DE EMPRESAS I",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-605",
                            Creditos = (byte)3,
                            Descripcion = "ESTRUCTURA DE DATOS",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-606",
                            Creditos = (byte)3,
                            Descripcion = "PROGRAMACION III",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-607",
                            Creditos = (byte)1,
                            Descripcion = "LAB. PROGRAMACION III",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "HUM-301",
                            Creditos = (byte)2,
                            Descripcion = "DOCTRINA SOCIAL DE LA IGLESIA",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)2
                        },
                        new
                        {
                            Clave = "ISC-777",
                            Creditos = (byte)0,
                            Descripcion = "PASANTIA I",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "ECO-235",
                            Creditos = (byte)3,
                            Descripcion = "ECOLOGIA Y PRESERVACION DEL MEDIO AMBIENTE",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)2
                        },
                        new
                        {
                            Clave = "CS-137",
                            Creditos = (byte)3,
                            Descripcion = "METODOLOGIA DE INVESTIGACION CIENTIFICA I",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-701",
                            Creditos = (byte)3,
                            Descripcion = "SISTEMAS OPERATIVOS I",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-702",
                            Creditos = (byte)1,
                            Descripcion = "LABORATORIO SISTEMAS OPERATIVOS I",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "ISC-703",
                            Creditos = (byte)3,
                            Descripcion = "BASE DE DATOS",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-704",
                            Creditos = (byte)1,
                            Descripcion = "LAB. BASE DE DATOS",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "ISC-705",
                            Creditos = (byte)2,
                            Descripcion = "MATENIMIENTO DE HARDWARE",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)1
                        },
                        new
                        {
                            Clave = "CNT-215",
                            Creditos = (byte)3,
                            Descripcion = "CONTABILIDAD GENERAL I",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "CNT-216",
                            Creditos = (byte)1,
                            Descripcion = "LABORATORIO DE CONTABILIDAD GENERAL I",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "ISC-706",
                            Creditos = (byte)2,
                            Descripcion = "PROYECTO APLICADO",
                            HorasPracticas = (byte)4,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "ISC-801",
                            Creditos = (byte)3,
                            Descripcion = "DISEÑO DE SISTEMAS",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)2
                        },
                        new
                        {
                            Clave = "ISC-802",
                            Creditos = (byte)3,
                            Descripcion = "ORG. Y ADM. DE SISTEMAS",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "IC-433",
                            Creditos = (byte)3,
                            Descripcion = "INGENIERIA ECONOMICA",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)2
                        },
                        new
                        {
                            Clave = "PSI-122",
                            Creditos = (byte)3,
                            Descripcion = "INTRODUCCION A LA PSICOLOGIA",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "MAT-221",
                            Creditos = (byte)4,
                            Descripcion = "ESTADISTICA GENERAL II",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-803",
                            Creditos = (byte)2,
                            Descripcion = "PROGRAMACION APLICADA I",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)2
                        },
                        new
                        {
                            Clave = "ISC-804",
                            Creditos = (byte)1,
                            Descripcion = "LAB. PROGRAMACION APLICADA I",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "CNT-227",
                            Creditos = (byte)3,
                            Descripcion = "CONTABILIDAD APLICADA",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)2
                        },
                        new
                        {
                            Clave = "ISC-901",
                            Creditos = (byte)3,
                            Descripcion = "SISTEMAS OPERATIVOS II",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-902",
                            Creditos = (byte)1,
                            Descripcion = "LABORATORIO SISTEMAS OPERATIVOS II",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "MAT-225",
                            Creditos = (byte)3,
                            Descripcion = "PROGRAMACION LINEAL PARA INGENIERIA",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)2
                        },
                        new
                        {
                            Clave = "ISC-903",
                            Creditos = (byte)4,
                            Descripcion = "LENGUAJE DE PROGRAMACION",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-904",
                            Creditos = (byte)3,
                            Descripcion = "TELEPROCESO Y REDES II",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-905",
                            Creditos = (byte)1,
                            Descripcion = "LAB. TELEPROCESO Y REDES II",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "ISC-906",
                            Creditos = (byte)2,
                            Descripcion = "ELECTIVA I",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)1
                        },
                        new
                        {
                            Clave = "ISC-101",
                            Creditos = (byte)2,
                            Descripcion = "PROGRAMACION APLICADA II",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)2
                        },
                        new
                        {
                            Clave = "ISC-102",
                            Creditos = (byte)1,
                            Descripcion = "LAB. PROGRAM. APLICADA II",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "ADM-321",
                            Creditos = (byte)3,
                            Descripcion = "TEORIA DE DECISIONES",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-103",
                            Creditos = (byte)3,
                            Descripcion = "TECNOLOGIAS DE INFORMACION",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-104",
                            Creditos = (byte)2,
                            Descripcion = "ELECTIVA II",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)1
                        },
                        new
                        {
                            Clave = "ADM-429",
                            Creditos = (byte)4,
                            Descripcion = "PLANIFICACION ESTRATEGICA",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)4
                        },
                        new
                        {
                            Clave = "ISC-105",
                            Creditos = (byte)3,
                            Descripcion = "METODOS NUMERICOS",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-106",
                            Creditos = (byte)1,
                            Descripcion = "LAB. METODOS NUMERICOS",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)1
                        },
                        new
                        {
                            Clave = "ISC-111",
                            Creditos = (byte)3,
                            Descripcion = "SIMULACION DIGITAL",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-112",
                            Creditos = (byte)4,
                            Descripcion = "INGENIERIA DE SOFTWARE",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-113",
                            Creditos = (byte)2,
                            Descripcion = "PROGRAMACION APLICADA III",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)2
                        },
                        new
                        {
                            Clave = "ISC-114",
                            Creditos = (byte)1,
                            Descripcion = "LAB. PROGRAMACION APLICADA III",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "ISC-115",
                            Creditos = (byte)3,
                            Descripcion = "ADM. DE CENTROS DE COMPUTOS",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)3
                        },
                        new
                        {
                            Clave = "ISC-116",
                            Creditos = (byte)3,
                            Descripcion = "MERCADEO DE SOFTWARE",
                            HorasPracticas = (byte)2,
                            HorasTeoricas = (byte)2
                        },
                        new
                        {
                            Clave = "HUM-117",
                            Creditos = (byte)2,
                            Descripcion = "ETICA PARA INGENIERIA DE SISTEMAS",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)2
                        },
                        new
                        {
                            Clave = "CS-232",
                            Creditos = (byte)2,
                            Descripcion = "MET. INVESTIGACION CIENTIF. II",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)2
                        },
                        new
                        {
                            Clave = "ISC-011",
                            Creditos = (byte)0,
                            Descripcion = "PASANTIA II",
                            HorasPracticas = (byte)0,
                            HorasTeoricas = (byte)0
                        },
                        new
                        {
                            Clave = "ISC-121",
                            Creditos = (byte)6,
                            Descripcion = "TESIS DE GRADO O CURSO AVANZADO",
                            HorasPracticas = (byte)6,
                            HorasTeoricas = (byte)3
                        });
                });

            modelBuilder.Entity("PensumProgresoAcademico.Entidades.Pensum", b =>
                {
                    b.Property<int>("PensumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Carrera")
                        .HasColumnType("TEXT");

                    b.Property<int>("Duracion")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PensumCreditos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PensumHorasPracticas")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PensumHorasTeoricas")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TituloOtorgar")
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalMaterias")
                        .HasColumnType("INTEGER");

                    b.HasKey("PensumId");

                    b.ToTable("Pensum");
                });

            modelBuilder.Entity("PensumProgresoAcademico.Entidades.PensumDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Clave")
                        .HasColumnType("TEXT");

                    b.Property<int>("PensumId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Prerequisitos")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Clave");

                    b.HasIndex("PensumId");

                    b.ToTable("PensumDetalle");
                });

            modelBuilder.Entity("PensumProgresoAcademico.Entidades.Estudiantes", b =>
                {
                    b.HasOne("PensumProgresoAcademico.Entidades.Pensum", "Pensum")
                        .WithMany()
                        .HasForeignKey("PensumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PensumProgresoAcademico.Entidades.Inscripciones", b =>
                {
                    b.HasOne("PensumProgresoAcademico.Entidades.Estudiantes", "Estudiante")
                        .WithMany()
                        .HasForeignKey("EstudianteMatricula");
                });

            modelBuilder.Entity("PensumProgresoAcademico.Entidades.InscripcionesDetalle", b =>
                {
                    b.HasOne("PensumProgresoAcademico.Entidades.Materias", "Materia")
                        .WithMany()
                        .HasForeignKey("Clave");

                    b.HasOne("PensumProgresoAcademico.Entidades.Inscripciones", null)
                        .WithMany("InscripcionesDetalles")
                        .HasForeignKey("InscripcionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PensumProgresoAcademico.Entidades.PensumDetalle", b =>
                {
                    b.HasOne("PensumProgresoAcademico.Entidades.Materias", "Materia")
                        .WithMany()
                        .HasForeignKey("Clave");

                    b.HasOne("PensumProgresoAcademico.Entidades.Pensum", null)
                        .WithMany("PensumDetalles")
                        .HasForeignKey("PensumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
