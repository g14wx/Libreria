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
    public class MiembroesController : Controller
    {
        private LibreriaContext db = new LibreriaContext();

        // GET: Miembroes
        public ActionResult Index()
        {
            return View(db.Miembros.ToList());
        }

        // GET: Miembroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembro miembro = db.Miembros.Find(id);
            if (miembro == null)
            {
                return HttpNotFound();
            }
            return View(miembro);
        }

        // GET: Miembroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Miembroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombres,Apellidos")] Miembro miembro)
        {
            if (ModelState.IsValid)
            {
                db.Miembros.Add(miembro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(miembro);
        }

        // GET: Miembroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembro miembro = db.Miembros.Find(id);
            if (miembro == null)
            {
                return HttpNotFound();
            }
            return View(miembro);
        }

        // POST: Miembroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombres,Apellidos")] Miembro miembro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miembro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(miembro);
        }

        // GET: Miembroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembro miembro = db.Miembros.Find(id);
            if (miembro == null)
            {
                return HttpNotFound();
            }
            return View(miembro);
        }

        // POST: Miembroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Miembro miembro = db.Miembros.Find(id);
            db.Miembros.Remove(miembro);
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
