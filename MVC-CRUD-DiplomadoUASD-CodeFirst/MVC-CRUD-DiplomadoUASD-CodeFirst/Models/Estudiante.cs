using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD_DiplomadoUASD_CodeFirst.Models
{
    public class Estudiante
    {
        public int EstudianteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime Fecha_Inscripcion { get; set; }
        public virtual ICollection<Inscripcion> Inscripciones { get; set; }
    }
}