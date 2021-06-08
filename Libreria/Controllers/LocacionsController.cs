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
    public class LocacionsController : Controller
    {
        private LibreriaContext db = new LibreriaContext();

        // GET: Locacions
        public ActionResult Index()
        {
            return View(db.Locacions.ToList());
        }

        // GET: Locacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locacion locacion = db.Locacions.Find(id);
            if (locacion == null)
            {
                return HttpNotFound();
            }
            return View(locacion);
        }

        // GET: Locacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nseccion,Narmario,NFila")] Locacion locacion)
        {
            if (ModelState.IsValid)
            {
                db.Locacions.Add(locacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locacion);
        }

        // GET: Locacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locacion locacion = db.Locacions.Find(id);
            if (locacion == null)
            {
                return HttpNotFound();
            }
            return View(locacion);
        }

        // POST: Locacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nseccion,Narmario,NFila")] Locacion locacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locacion);
        }

        // GET: Locacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locacion locacion = db.Locacions.Find(id);
            if (locacion == null)
            {
                return HttpNotFound();
            }
            return View(locacion);
        }

        // POST: Locacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Locacion locacion = db.Locacions.Find(id);
            db.Locacions.Remove(locacion);
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
