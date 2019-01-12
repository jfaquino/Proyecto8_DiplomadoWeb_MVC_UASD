using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using MVC_CRUD_DiplomadoUASD_CodeFirst.Datos;
using MVC_CRUD_DiplomadoUASD_CodeFirst.Models;

namespace MVC_CRUD_DiplomadoUASD_CodeFirst.Controllers
{
    public class EmpleadosController : Controller
    {
        private EmpleadoContext db = new EmpleadoContext();

        public FileResult ExportarEmpleadosCSV()
        {

            //Indicamos las columnas que tendra el archivo generado por la accion.
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[4]
            {new DataColumn("Código"),
             new DataColumn("Nombres"),
             new DataColumn("Apellidos"),
             new DataColumn("Fecha_Ingreso")
            });

            //Aplicamos una sentencia LINQ para obtener la informacion.

            var empleados = from Empleado in db.Empleados where Empleado.Apellidos.Contains("A")
                            select Empleado;

            //Recorremos la coleccion de empleados y agregamos cadafila en el archivo que será generado.
            foreach(var empleado in empleados)
            {
                dt.Rows.Add(empleado.EmpleadoId, empleado.Nombres, empleado.Apellidos, empleado.Fecha_Ingreso);
            }

            //Indicamos el tipo de objeto que se estará generando, en este caso un archivo excel.
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
            }
        }

        // GET: Empleados
        public ActionResult Index()
        {
            return View(db.Empleados.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpleadoId,Nombres,Apellidos,Fecha_Ingreso")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpleadoId,Nombres,Apellidos,Fecha_Ingreso")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleados.Find(id);
            db.Empleados.Remove(empleado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
