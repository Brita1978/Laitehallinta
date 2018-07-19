using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Laitehallinta.Models;

namespace Laitehallinta.Controllers
{
    public class TilaController : Controller
    {
        private SeurantaEntities db = new SeurantaEntities();

        // GET: Haku
        public ActionResult Index(string searching)
        {
            return View(db.Tilat.Where(x => x.Tarkennus.StartsWith(searching) || searching == null).ToList());
        }
        /*
        // GET: Tila
        public ActionResult Index()
        {
            return View(db.Tilat.ToList());
        }
        */
        // GET: Tila/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tilat tilat = db.Tilat.Find(id);
            if (tilat == null)
            {
                return HttpNotFound();
            }
            return View(tilat);
        }

        // GET: Tila/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tila/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TilaID,Tarkennus")] Tilat tilat)
        {
            if (ModelState.IsValid)
            {
                db.Tilat.Add(tilat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tilat);
        }

        // GET: Tila/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tilat tilat = db.Tilat.Find(id);
            if (tilat == null)
            {
                return HttpNotFound();
            }
            return View(tilat);
        }

        // POST: Tila/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TilaID,Tarkennus")] Tilat tilat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tilat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tilat);
        }

        // GET: Tila/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tilat tilat = db.Tilat.Find(id);
            if (tilat == null)
            {
                return HttpNotFound();
            }
            return View(tilat);
        }

        // POST: Tila/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tilat tilat = db.Tilat.Find(id);
            db.Tilat.Remove(tilat);
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
