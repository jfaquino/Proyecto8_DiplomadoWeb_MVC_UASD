using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using MVC_CRUD_DiplomadoUASD_CodeFirst.Models;

namespace MVC_CRUD_DiplomadoUASD_CodeFirst.Datos
{
    public class EstudianteContext : DbContext 
    {
        public EstudianteContext()
            : base("EstudianteContext")
            {}

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}