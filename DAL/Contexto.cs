using Microsoft.EntityFrameworkCore;
using PensumProgresoAcademico.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PensumProgresoAcademico.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Pensum> Pensum { get; set; }
        public DbSet<Inscripciones> Inscripciones { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Materias> Materias { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\PensumProgresoAcademico.db");
        }

        //Se crearon todas las materias del pensum
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "HUM-111",
                Descripcion = "LENGUA ESPAÑOLA Y TECNICA DE EXPRESION I",
                HorasPracticas = 0,
                HorasTeoricas = 4,
                Creditos = 4
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "CS-115",
                Descripcion = "INTRODUCCION AL ESTUDIO DE LAS CIENCIAS SOCIALES",
                HorasPracticas = 0,
                HorasTeoricas = 2,
                Creditos = 2
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ING-111",
                Descripcion = "INGLES ELEMENTAL I",
                HorasPracticas = 2,
                HorasTeoricas = 3,
                Creditos = 4
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "MAT-112",
                Descripcion = "MATEMATICA BASICA I",
                HorasPracticas = 2,
                HorasTeoricas = 3,
                Creditos = 4
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ORI-116",
                Descripcion = "ORIENTACION ACADEMICA",
                HorasPracticas = 0,
                HorasTeoricas = 1,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "QMA-117",
                Descripcion = "QUIMICA I",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "QMA-118",
                Descripcion = "LABORATORIO QUIMICA I",
                HorasPracticas = 2,
                HorasTeoricas = 0,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "CS-126",
                Descripcion = "HISTORIA SOCIAL DOMINICANA",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "HUM-121",
                Descripcion = "LENGUA ESPAÑOLA Y TECNICA EXPRESION II",
                HorasPracticas = 0,
                HorasTeoricas = 4,
                Creditos = 4
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "MAT-125",
                Descripcion = "PRECALCULO",
                HorasPracticas = 2,
                HorasTeoricas = 3,
                Creditos = 4
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "FIS-127",
                Descripcion = "FISICA BASICA",
                HorasPracticas = 2,
                HorasTeoricas = 3,
                Creditos = 4
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "FIS-128",
                Descripcion = "LABORATORIO FISICA BASICA",
                HorasPracticas = 2,
                HorasTeoricas = 0,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ING-221",
                Descripcion = "INGLES ELEMENTAL II",
                HorasPracticas = 2,
                HorasTeoricas = 3,
                Creditos = 4
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-201",
                Descripcion = "INTRODUCCION A LA INGENIERIA DE SISTEMAS",
                HorasPracticas = 0,
                HorasTeoricas = 2,
                Creditos = 2
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-202",
                Descripcion = "LABORATORIO INTRODUCCION A LA INGENIERIA DE SISTEMAS",
                HorasPracticas = 2,
                HorasTeoricas = 0,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "FIS-134",
                Descripcion = "FISICA I",
                HorasPracticas = 2,
                HorasTeoricas = 4,
                Creditos = 5
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "FIS-135",
                Descripcion = "LABORATORIO FISICA I",
                HorasPracticas = 2,
                HorasTeoricas = 0,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "HUM-291",
                Descripcion = "EDUCACION EN VALORES",
                HorasPracticas = 0,
                HorasTeoricas = 2,
                Creditos = 2
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "MAT-136",
                Descripcion = "CALCULO I",
                HorasPracticas = 2,
                HorasTeoricas = 4,
                Creditos = 5
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ING-315",
                Descripcion = "INGLES INTERMEDIO I",
                HorasPracticas = 2,
                HorasTeoricas = 3,
                Creditos = 4
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-301",
                Descripcion = "TECNICA DE PROGRAMACION",
                HorasPracticas = 0,
                HorasTeoricas = 2,
                Creditos = 2
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-302",
                Descripcion = "LABORATORIO TECNICA DE PROGRAMACION",
                HorasPracticas = 2,
                HorasTeoricas = 0,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ORI-127",
                Descripcion = "ACTIVIDAD CO-CURRICULAR",
                HorasPracticas = 2,
                HorasTeoricas = 0,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "FIS-218",
                Descripcion = "FISICA II",
                HorasPracticas = 2,
                HorasTeoricas = 4,
                Creditos = 5
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "FIS-219",
                Descripcion = "LABORATORIO FISICA II",
                HorasPracticas = 2,
                HorasTeoricas = 0,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "MAT-215",
                Descripcion = "CALCULO II",
                HorasPracticas = 2,
                HorasTeoricas = 4,
                Creditos = 5
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ING-424",
                Descripcion = "INGLES PARA SISTEMAS",
                HorasPracticas = 2,
                HorasTeoricas = 3,
                Creditos = 4
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-401",
                Descripcion = "PROGRAMACION I",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-402",
                Descripcion = "LABORATORIO PROGRAMACION I",
                HorasPracticas = 2,
                HorasTeoricas = 0,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "MAT-229",
                Descripcion = "CALCULO III",
                HorasPracticas = 2,
                HorasTeoricas = 4,
                Creditos = 5
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-501",
                Descripcion = "ELECTRONICA APLICADA",
                HorasPracticas = 2,
                HorasTeoricas = 3,
                Creditos = 4
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "MAT-211",
                Descripcion = "ESTADISTICA GENERAL I",
                HorasPracticas = 2,
                HorasTeoricas = 3,
                Creditos = 4
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-502",
                Descripcion = "PROGRAMACION II",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-503",
                Descripcion = "LABORATORIO DE PROGRAMACION II",
                HorasPracticas = 2,
                HorasTeoricas = 0,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "EC-131",
                Descripcion = "INTRODUCCION A LA ECONOMIA",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "HUM-300",
                Descripcion = "BIOETICA",
                HorasPracticas = 0,
                HorasTeoricas = 2,
                Creditos = 2
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-601",
                Descripcion = "ANALISIS DE SISTEMAS",
                HorasPracticas = 2,
                HorasTeoricas = 2,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-602",
                Descripcion = "TELEPROCESO Y REDES I",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-603",
                Descripcion = "LAB. TELEPROCESO Y REDES I",
                HorasPracticas = 2,
                HorasTeoricas = 0,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-604",
                Descripcion = "ARQUITECTURA DEL COMPUTADOR",
                HorasPracticas = 0,
                HorasTeoricas = 2,
                Creditos = 2
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ADM-311",
                Descripcion = "ADMINISTRACION DE EMPRESAS I",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-605",
                Descripcion = "ESTRUCTURA DE DATOS",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-606",
                Descripcion = "PROGRAMACION III",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-607",
                Descripcion = "LAB. PROGRAMACION III",
                HorasPracticas = 2,
                HorasTeoricas = 0,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "HUM-301",
                Descripcion = "DOCTRINA SOCIAL DE LA IGLESIA",
                HorasPracticas = 0,
                HorasTeoricas = 2,
                Creditos = 2
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-777",
                Descripcion = "PASANTIA I",
                HorasPracticas = 0,
                HorasTeoricas = 0,
                Creditos = 0
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ECO-235",
                Descripcion = "ECOLOGIA Y PRESERVACION DEL MEDIO AMBIENTE",
                HorasPracticas = 2,
                HorasTeoricas = 2,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "CS-137",
                Descripcion = "METODOLOGIA DE INVESTIGACION CIENTIFICA I",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-701",
                Descripcion = "SISTEMAS OPERATIVOS I",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-702",
                Descripcion = "LABORATORIO SISTEMAS OPERATIVOS I",
                HorasPracticas = 2,
                HorasTeoricas = 0,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-703",
                Descripcion = "BASE DE DATOS",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-704",
                Descripcion = "LAB. BASE DE DATOS",
                HorasPracticas = 2,
                HorasTeoricas = 0,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-705",
                Descripcion = "MATENIMIENTO DE HARDWARE",
                HorasPracticas = 2,
                HorasTeoricas = 1,
                Creditos = 2
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "CNT-215",
                Descripcion = "CONTABILIDAD GENERAL I",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "CNT-216",
                Descripcion = "LABORATORIO DE CONTABILIDAD GENERAL I",
                HorasPracticas = 2,
                HorasTeoricas = 0,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-706",
                Descripcion = "PROYECTO APLICADO",
                HorasPracticas = 4,
                HorasTeoricas = 0,
                Creditos = 2
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-801",
                Descripcion = "DISEÑO DE SISTEMAS",
                HorasPracticas = 2,
                HorasTeoricas = 2,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-802",
                Descripcion = "ORG. Y ADM. DE SISTEMAS",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "IC-433",
                Descripcion = "INGENIERIA ECONOMICA",
                HorasPracticas = 2,
                HorasTeoricas = 2,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "PSI-122",
                Descripcion = "INTRODUCCION A LA PSICOLOGIA",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "MAT-221",
                Descripcion = "ESTADISTICA GENERAL II",
                HorasPracticas = 2,
                HorasTeoricas = 3,
                Creditos = 4
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-803",
                Descripcion = "PROGRAMACION APLICADA I",
                HorasPracticas = 0,
                HorasTeoricas = 2,
                Creditos = 2
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-804",
                Descripcion = "LAB. PROGRAMACION APLICADA I",
                HorasPracticas = 2,
                HorasTeoricas = 0,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "CNT-227",
                Descripcion = "CONTABILIDAD APLICADA",
                HorasPracticas = 2,
                HorasTeoricas = 2,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-901",
                Descripcion = "SISTEMAS OPERATIVOS II",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-902",
                Descripcion = "LABORATORIO SISTEMAS OPERATIVOS II",
                HorasPracticas = 2,
                HorasTeoricas = 0,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "MAT-225",
                Descripcion = "PROGRAMACION LINEAL PARA INGENIERIA",
                HorasPracticas = 2,
                HorasTeoricas = 2,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-903",
                Descripcion = "LENGUAJE DE PROGRAMACION",
                HorasPracticas = 2,
                HorasTeoricas = 3,
                Creditos = 4
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-904",
                Descripcion = "TELEPROCESO Y REDES II",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-905",
                Descripcion = "LAB. TELEPROCESO Y REDES II",
                HorasPracticas = 2,
                HorasTeoricas = 0,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-906",
                Descripcion = "ELECTIVA I",
                HorasPracticas = 2,
                HorasTeoricas = 1,
                Creditos = 2
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-101",
                Descripcion = "PROGRAMACION APLICADA II",
                HorasPracticas = 0,
                HorasTeoricas = 2,
                Creditos = 2
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-102",
                Descripcion = "LAB. PROGRAM. APLICADA II",
                HorasPracticas = 2,
                HorasTeoricas = 0,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ADM-321",
                Descripcion = "TEORIA DE DECISIONES",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-103",
                Descripcion = "TECNOLOGIAS DE INFORMACION",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-104",
                Descripcion = "ELECTIVA II",
                HorasPracticas = 2,
                HorasTeoricas = 1,
                Creditos = 2
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ADM-429",
                Descripcion = "PLANIFICACION ESTRATEGICA",
                HorasPracticas = 0,
                HorasTeoricas = 4,
                Creditos = 4
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-105",
                Descripcion = "METODOS NUMERICOS",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-106",
                Descripcion = "LAB. METODOS NUMERICOS",
                HorasPracticas = 2,
                HorasTeoricas = 1,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-111",
                Descripcion = "SIMULACION DIGITAL",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-112",
                Descripcion = "INGENIERIA DE SOFTWARE",
                HorasPracticas = 2,
                HorasTeoricas = 3,
                Creditos = 4
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-113",
                Descripcion = "PROGRAMACION APLICADA III",
                HorasPracticas = 0,
                HorasTeoricas = 2,
                Creditos = 2
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-114",
                Descripcion = "LAB. PROGRAMACION APLICADA III",
                HorasPracticas = 2,
                HorasTeoricas = 0,
                Creditos = 1
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-115",
                Descripcion = "ADM. DE CENTROS DE COMPUTOS",
                HorasPracticas = 0,
                HorasTeoricas = 3,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-116",
                Descripcion = "MERCADEO DE SOFTWARE",
                HorasPracticas = 2,
                HorasTeoricas = 2,
                Creditos = 3
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "HUM-117",
                Descripcion = "ETICA PARA INGENIERIA DE SISTEMAS",
                HorasPracticas = 0,
                HorasTeoricas = 2,
                Creditos = 2
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "CS-232",
                Descripcion = "MET. INVESTIGACION CIENTIF. II",
                HorasPracticas = 0,
                HorasTeoricas = 2,
                Creditos = 2
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-011",
                Descripcion = "PASANTIA II",
                HorasPracticas = 0,
                HorasTeoricas = 0,
                Creditos = 0
            });

            modelBuilder.Entity<Materias>().HasData(new Materias
            {
                Clave = "ISC-121",
                Descripcion = "TESIS DE GRADO O CURSO AVANZADO",
                HorasPracticas = 6,
                HorasTeoricas = 3,
                Creditos = 6
            });

        }
    }
    
}
