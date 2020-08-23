using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PensumProgresoAcademico.Entidades
{
    public class PensumDetalle
    {
        public int Id { get; set; }
        public int PensumId { get; set; }
        public string Clave { get; set; }

        [ForeignKey("Clave")]
        public Materias Materia { get; set; }
    }
}
