using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD_DiplomadoUASD_CodeFirst.Models
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Registro> Registros { get; set; }
    }
}