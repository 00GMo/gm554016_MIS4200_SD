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
    public class GamesController : Controller
    {
        private GameLibraryContext db = new GameLibraryContext();

        // GET: Games
        public ActionResult Index()
        {
            var game = db.game.Include(g => g.consoles).Include(g => g.owner).Include(g => g.publisher);
            return View(game.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.game.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.consolesID = new SelectList(db.consoles, "consolesID", "consoleName");
            ViewBag.ownerID = new SelectList(db.owner, "ownerID", "fullName");
            ViewBag.publisherID = new SelectList(db.publisher, "publisherID", "publisherName");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "gameID,gameTitle,gameSeries,genreOne,genreTwo,releaseDate,description,consolesID,ownerID,publisherID")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.game.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.consolesID = new SelectList(db.consoles, "consolesID", "consoleName", game.consolesID);
            ViewBag.ownerID = new SelectList(db.owner, "ownerID", "firstName", game.ownerID);
            ViewBag.publisherID = new SelectList(db.publisher, "publisherID", "publisherName", game.publisherID);
            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.game.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.consolesID = new SelectList(db.consoles, "consolesID", "consoleName", game.consolesID);
            ViewBag.ownerID = new SelectList(db.owner, "ownerID", "firstName", game.ownerID);
            ViewBag.publisherID = new SelectList(db.publisher, "publisherID", "publisherName", game.publisherID);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "gameID,gameTitle,gameSeries,genreOne,genreTwo,releaseDate,description,consolesID,ownerID,publisherID")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.consolesID = new SelectList(db.consoles, "consolesID", "consoleName", game.consolesID);
            ViewBag.ownerID = new SelectList(db.owner, "ownerID", "firstName", game.ownerID);
            ViewBag.publisherID = new SelectList(db.publisher, "publisherID", "publisherName", game.publisherID);
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.game.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.game.Find(id);
            db.game.Remove(game);
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
