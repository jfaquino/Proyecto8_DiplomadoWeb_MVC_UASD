using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD_DiplomadoUASD_CodeFirst.Datos;
using MVC_CRUD_DiplomadoUASD_CodeFirst.Models;

namespace MVC_CRUD_DiplomadoUASD_CodeFirst.Controllers
{
    public class RegistrosController : Controller
    {
        private EmpleadoContext db = new EmpleadoContext();

        // GET: Registros
        public ActionResult Index()
        {
            var registros = db.Registros.Include(r => r.Departamento).Include(r => r.Empleado);
            return View(registros.ToList());
        }

        // GET: Registros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.Registros.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // GET: Registros/Create
        public ActionResult Create()
        {
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "Descripcion");
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombres");
            return View();
        }

        // POST: Registros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegistroId,Sueldo,DepartamentoId,EmpleadoId")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                db.Registros.Add(registro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "Descripcion", registro.DepartamentoId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombres", registro.EmpleadoId);
            return View(registro);
        }

        // GET: Registros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.Registros.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "Descripcion", registro.DepartamentoId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombres", registro.EmpleadoId);
            return View(registro);
        }

        // POST: Registros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegistroId,Sueldo,DepartamentoId,EmpleadoId")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "Descripcion", registro.DepartamentoId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombres", registro.EmpleadoId);
            return View(registro);
        }

        // GET: Registros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.Registros.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // POST: Registros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registro registro = db.Registros.Find(id);
            db.Registros.Remove(registro);
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
