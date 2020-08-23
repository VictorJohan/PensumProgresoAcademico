using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PensumProgresoAcademico.Entidades
{
    public class Materias
    {
        [Key]
        public string Clave { get; set; }
        public int SemestreId { get; set; }
        public int IdMatricula { get; set; }
        public string Descripcion { get; set; }
        public byte HorasPracticas { get; set; }
        public byte HorasTeoricas { get; set; }
        public byte Creditos { get; set; }
        public string Prerequisitos { get; set; }
    }
}
