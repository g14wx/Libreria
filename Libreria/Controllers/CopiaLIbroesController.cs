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
    public class CopiaLIbroesController : Controller
    {
        private LibreriaContext db = new LibreriaContext();

        // GET: CopiaLIbroes
        public ActionResult Index()
        {
            var copiaLIbros = db.CopiaLIbros.Include(c => c.Libro).Include(c => c.Locacion);
            return View(copiaLIbros.ToList());
        }

        // GET: CopiaLIbroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CopiaLIbro copiaLIbro = db.CopiaLIbros.Find(id);
            if (copiaLIbro == null)
            {
                return HttpNotFound();
            }
            return View(copiaLIbro);
        }

        // GET: CopiaLIbroes/Create
        public ActionResult Create()
        {
            ViewBag.LibroID = new SelectList(db.Libros, "ID", "Titulo");
            ViewBag.LocacionID = new SelectList(db.Locacions, "ID", "ID");
            return View();
        }

        // POST: CopiaLIbroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Identificador,Estado,EstadoGeneral,LibroID,LocacionID")] CopiaLIbro copiaLIbro)
        {
            if (ModelState.IsValid)
            {
                db.CopiaLIbros.Add(copiaLIbro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LibroID = new SelectList(db.Libros, "ID", "Titulo", copiaLIbro.LibroID);
            ViewBag.LocacionID = new SelectList(db.Locacions, "ID", "ID", copiaLIbro.LocacionID);
            return View(copiaLIbro);
        }

        // GET: CopiaLIbroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CopiaLIbro copiaLIbro = db.CopiaLIbros.Find(id);
            if (copiaLIbro == null)
            {
                return HttpNotFound();
            }
            ViewBag.LibroID = new SelectList(db.Libros, "ID", "Titulo", copiaLIbro.LibroID);
            ViewBag.LocacionID = new SelectList(db.Locacions, "ID", "ID", copiaLIbro.LocacionID);
            return View(copiaLIbro);
        }

        // POST: CopiaLIbroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Identificador,Estado,EstadoGeneral,LibroID,LocacionID")] CopiaLIbro copiaLIbro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(copiaLIbro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LibroID = new SelectList(db.Libros, "ID", "Titulo", copiaLIbro.LibroID);
            ViewBag.LocacionID = new SelectList(db.Locacions, "ID", "ID", copiaLIbro.LocacionID);
            return View(copiaLIbro);
        }

        // GET: CopiaLIbroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CopiaLIbro copiaLIbro = db.CopiaLIbros.Find(id);
            if (copiaLIbro == null)
            {
                return HttpNotFound();
            }
            return View(copiaLIbro);
        }

        // POST: CopiaLIbroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CopiaLIbro copiaLIbro = db.CopiaLIbros.Find(id);
            db.CopiaLIbros.Remove(copiaLIbro);
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
