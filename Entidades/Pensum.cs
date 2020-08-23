using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PensumProgresoAcademico.Entidades
{
    public class Pensum
    {
        [Key]
        public int PensumId { get; set; }
        public string Carrera { get; set; }
        public int Duracion { get; set; }
        public string TituloOtorgar { get; set; }
        public int TotalMaterias { get; set; }
        public int PensumHorasPracticas { get; set; }
        public int PensumHorasTeoricas { get; set; }
        public int PensumCreditos { get; set; }

        [ForeignKey("SemestreId")]
        public virtual List<Semestres> Semestres { get; set; } = new List<Semestres>();
    }
}
