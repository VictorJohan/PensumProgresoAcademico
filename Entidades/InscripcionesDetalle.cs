using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PensumProgresoAcademico.Entidades
{
    public class InscripcionesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int InscripcionId { get; set; }
        public string Clave { get; set; }

        [ForeignKey("Clave")]
        public virtual Materias Materia { get; set; }
    }
}
