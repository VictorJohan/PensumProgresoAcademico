using Microsoft.EntityFrameworkCore;
using PensumProgresoAcademico.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PensumProgresoAcademico.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Pensum> Pensums { get; set; }
        public DbSet<Inscripciones> Matriculas { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Materias> Materias { get; set; }

    }
}
