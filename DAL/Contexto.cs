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
    }
    
}
