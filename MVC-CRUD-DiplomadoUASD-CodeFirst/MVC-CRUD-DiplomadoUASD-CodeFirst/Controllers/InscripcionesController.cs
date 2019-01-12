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
    public class InscripcionesController : Controller
    {
        private EstudianteContext db = new EstudianteContext();

        // GET: Inscripciones
        public ActionResult Index()
        {
            var inscripciones = db.Inscripciones.Include(i => i.Curso).Include(i => i.Estudiante);
            return View(inscripciones.ToList());
        }

        // GET: Inscripciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcion inscripcion = db.Inscripciones.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            return View(inscripcion);
        }

        // GET: Inscripciones/Create
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "Descripcion");
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "EstudianteId", "Nombres");
            return View();
        }

        // POST: Inscripciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InscripcionId,CursoId,EstudianteId,Semestre")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Inscripciones.Add(inscripcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "Descripcion", inscripcion.CursoId);
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "EstudianteId", "Nombres", inscripcion.EstudianteId);
            return View(inscripcion);
        }

        // GET: Inscripciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcion inscripcion = db.Inscripciones.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "Descripcion", inscripcion.CursoId);
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "EstudianteId", "Nombres", inscripcion.EstudianteId);
            return View(inscripcion);
        }

        // POST: Inscripciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InscripcionId,CursoId,EstudianteId,Semestre")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscripcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "Descripcion", inscripcion.CursoId);
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "EstudianteId", "Nombres", inscripcion.EstudianteId);
            return View(inscripcion);
        }

        // GET: Inscripciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcion inscripcion = db.Inscripciones.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            return View(inscripcion);
        }

        // POST: Inscripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscripcion inscripcion = db.Inscripciones.Find(id);
            db.Inscripciones.Remove(inscripcion);
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
