using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD_DiplomadoUASD_CodeFirst.Models
{
    public class Registro
    {
        public int RegistroId { get; set; }
        public Nullable<decimal> Sueldo { get; set; }
        public int DepartamentoId { get; set; }
        public int EmpleadoId { get; set; }

        public virtual Departamento Departamento { get; set; }
        public virtual Empleado Empleado { get; set; }
    }
}