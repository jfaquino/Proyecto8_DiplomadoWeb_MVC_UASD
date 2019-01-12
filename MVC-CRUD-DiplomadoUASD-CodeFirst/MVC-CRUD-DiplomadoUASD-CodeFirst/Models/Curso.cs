using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD_DiplomadoUASD_CodeFirst.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Inscripcion> Inscripciones { get; set; }
    }
}