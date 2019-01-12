using MVC_CRUD_DiplomadoUASD_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_CRUD_DiplomadoUASD_CodeFirst.Datos
{
    public class CargarDatosDB : DropCreateDatabaseIfModelChanges<EmpleadoContext>
    {
        protected override void Seed(EmpleadoContext context)
        {
            var departamentos = new List<Departamento>
            {
                new Departamento{DepartamentoId = 1, Descripcion = "Programación"},
                new Departamento{DepartamentoId = 2, Descripcion = "Recursos Humanos"},
                new Departamento{DepartamentoId = 3, Descripcion = "Mercadeo"}
            };
            departamentos.ForEach(item => context.Departamentos.Add(item));
            context.SaveChanges();

            var empleados = new List<Empleado>
            {
                new Empleado{Nombres = "Juan Carlos", Apellidos = "Reyes Jimenez", Fecha_Ingreso = DateTime.Parse("2001-09-01")},
                new Empleado{Nombres = "Belkis", Apellidos = "Sandoval Polanco", Fecha_Ingreso = DateTime.Parse("2002-10-25")},
                new Empleado{Nombres = "Pedro", Apellidos = "Martinez Perez", Fecha_Ingreso = DateTime.Parse("2003-01-16")},
                new Empleado{Nombres = "Josue", Apellidos = "Francisco Jimenez", Fecha_Ingreso = DateTime.Parse("2003-09-15")}
            };
            empleados.ForEach(item => context.Empleados.Add(item));
            context.SaveChanges();

            var registros = new List<Registro>
            {
                new Registro{EmpleadoId = 1, DepartamentoId = 1, Sueldo = Convert.ToDecimal(10000.00)},
                new Registro{EmpleadoId = 2, DepartamentoId = 1, Sueldo = Convert.ToDecimal(25000.00)},
                new Registro{EmpleadoId = 3, DepartamentoId = 2, Sueldo = Convert.ToDecimal(15400.00)},
                new Registro{EmpleadoId = 4, DepartamentoId = 2, Sueldo = Convert.ToDecimal(12500.00)}
            };
            registros.ForEach(item => context.Registros.Add(item));
            context.SaveChanges();
        }
    }
}