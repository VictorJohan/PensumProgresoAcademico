using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PensumProgresoAcademico.Entidades
{
    public class Semestres
    {
        [Key]
        public int Id { get; set; }
        public int PensumId { get; set; }
        public int SemestreId { get; set; }
        public byte TotalHorasPracticas { get; set; }
        public byte TotalHorasTeoricas { get; set; }
        public byte TotalCreditos { get; set; }

        [ForeignKey("SemestreId")]
        public virtual List<Materias> Materias { get; set; } = new List<Materias>();
    }
}
