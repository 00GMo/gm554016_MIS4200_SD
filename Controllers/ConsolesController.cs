using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gm554016.DAL;
using gm554016.Models;

namespace gm554016.Controllers
{
    public class ConsolesController : Controller
    {
        private GameLibraryContext db = new GameLibraryContext();

        // GET: Consoles
        public ActionResult Index()
        {
            var consoles = db.consoles.Include(c => c.developer);
            return View(consoles.ToList());
        }

        // GET: Consoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consoles consoles = db.consoles.Find(id);
            if (consoles == null)
            {
                return HttpNotFound();
            }
            return View(consoles);
        }

        // GET: Consoles/Create
        public ActionResult Create()
        {
            ViewBag.developerID = new SelectList(db.developer, "developerID", "developerName");
            return View();
        }

        // POST: Consoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "consolesID,consoleName,releaseDate,description,developerID")] Consoles consoles)
        {
            if (ModelState.IsValid)
            {
                db.consoles.Add(consoles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.developerID = new SelectList(db.developer, "developerID", "developerName", consoles.developerID);
            return View(consoles);
        }

        // GET: Consoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consoles consoles = db.consoles.Find(id);
            if (consoles == null)
            {
                return HttpNotFound();
            }
            ViewBag.developerID = new SelectList(db.developer, "developerID", "developerName", consoles.developerID);
            return View(consoles);
        }

        // POST: Consoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "consolesID,consoleName,releaseDate,description,developerID")] Consoles consoles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consoles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.developerID = new SelectList(db.developer, "developerID", "developerName", consoles.developerID);
            return View(consoles);
        }

        // GET: Consoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consoles consoles = db.consoles.Find(id);
            if (consoles == null)
            {
                return HttpNotFound();
            }
            return View(consoles);
        }

        // POST: Consoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consoles consoles = db.consoles.Find(id);
            db.consoles.Remove(consoles);
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
