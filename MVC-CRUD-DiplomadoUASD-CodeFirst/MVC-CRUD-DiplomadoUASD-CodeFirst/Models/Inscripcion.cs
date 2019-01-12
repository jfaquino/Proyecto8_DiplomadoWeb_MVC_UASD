using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD_DiplomadoUASD_CodeFirst.Models
{
    public class Inscripcion
    {
        public int InscripcionId { get; set; }
        public int CursoId { get; set; }
        public int EstudianteId { get; set; }
        public int Semestre { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual Estudiante Estudiante { get; set; }
    }
}