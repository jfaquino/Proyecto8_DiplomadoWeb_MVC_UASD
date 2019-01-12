using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MVC_CRUD_DiplomadoUASD_CodeFirst.Models;

namespace MVC_CRUD_DiplomadoUASD_CodeFirst.Datos
{
    public class EmpleadoContext : DbContext
    {
        public EmpleadoContext()
            : base("EmpleadoContext")
        {
            Database.SetInitializer(new CargarDatosDB());
        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Registro> Registros { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}