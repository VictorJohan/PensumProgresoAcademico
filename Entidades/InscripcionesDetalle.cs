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
        public string Clave { get; set; }//todo: Puedo que esta propiedad y la de la linea 18 no sea necesaria ya que las materias del pensum se pueden meter en un comboBox

        [ForeignKey("Clave")]
        public Materias Materia { get; set; }
    }
}
