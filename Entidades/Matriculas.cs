using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PensumProgresoAcademico.Entidades
{
    public class Matriculas
    {
        [Key]
        public int IdMatricula { get; set; }
        public int Matricula { get; set; }
        public int CreditosSelccionados { get; set; }
        public int CantidadMateria { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

        [ForeignKey("Matricula")]
        public Estudiantes Estudiante { get; set; }

        [ForeignKey("IdMatricula")]
        public virtual List<Materias> Materias { get; set; } = new List<Materias>();

    }
}
