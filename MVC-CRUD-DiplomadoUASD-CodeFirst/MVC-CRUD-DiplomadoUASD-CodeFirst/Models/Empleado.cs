using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD_DiplomadoUASD_CodeFirst.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string  Nombres { get; set; }
        public string Apellidos { get; set; }
        public Nullable<DateTime>  Fecha_Ingreso { get; set; }
        public virtual ICollection<Registro> Registros { get; set; }
    }
}