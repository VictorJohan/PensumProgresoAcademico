using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PensumProgresoAcademico.Entidades
{
    public class Estudiantes
    {
        [Key]
        public int Matricula { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public int MateriasPendientes { get; set; }
        public int HorasPracticasPendientes { get; set; }
        public int HorasTeoricasPendientes { get; set; }
        public int CreditosPendientes { get; set; }
        public int PensumId { get; set; }

        [ForeignKey("PensumId")]
        public Pensum Pensum { get; set; }
    }
}
