using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Libreria.DAL;
using Libreria.Models;

namespace Libreria.Controllers
{
    public class PrestamoesController : Controller
    {
        private LibreriaContext db = new LibreriaContext();

        // GET: Prestamoes
        public ActionResult Index()
        {
            var prestamos = db.Prestamos.Include(p => p.CopiaLIbro).Include(p => p.Miembro);
            return View(prestamos.ToList());
        }

        // GET: Prestamoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // GET: Prestamoes/Create
        public ActionResult Create()
        {
            ViewBag.CopiaLibroID = new SelectList(db.CopiaLIbros, "ID", "Identificador");
            ViewBag.MiembroID = new SelectList(db.Miembros, "ID", "Nombres");
            return View();
        }

        // POST: Prestamoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FechaRetorno,FechaDePrestamo,Comentarios,CopiaLibroID,MiembroID")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Prestamos.Add(prestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CopiaLibroID = new SelectList(db.CopiaLIbros, "ID", "Identificador", prestamo.CopiaLibroID);
            ViewBag.MiembroID = new SelectList(db.Miembros, "ID", "Nombres", prestamo.MiembroID);
            return View(prestamo);
        }

        // GET: Prestamoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CopiaLibroID = new SelectList(db.CopiaLIbros, "ID", "Identificador", prestamo.CopiaLibroID);
            ViewBag.MiembroID = new SelectList(db.Miembros, "ID", "Nombres", prestamo.MiembroID);
            return View(prestamo);
        }

        // POST: Prestamoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FechaRetorno,FechaDePrestamo,Comentarios,CopiaLibroID,MiembroID")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CopiaLibroID = new SelectList(db.CopiaLIbros, "ID", "Identificador", prestamo.CopiaLibroID);
            ViewBag.MiembroID = new SelectList(db.Miembros, "ID", "Nombres", prestamo.MiembroID);
            return View(prestamo);
        }

        // GET: Prestamoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // POST: Prestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prestamo prestamo = db.Prestamos.Find(id);
            db.Prestamos.Remove(prestamo);
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
