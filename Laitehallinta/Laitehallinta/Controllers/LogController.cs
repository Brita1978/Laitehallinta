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
    public class LogController : Controller
    {
        private SeurantaEntities db = new SeurantaEntities();

        // GET: Haku
        public ActionResult Index(string searching)

        {

            return View(db.Logi.Where(i => i.Laitteet.Merkki.Equals(searching) || searching == null).ToList());
        }
        /*
        // GET: Log
        public ActionResult Index()
        {
            var logi = db.Logi.Include(l => l.Henkilot).Include(l => l.Laitteet).Include(l => l.Tilat);
            return View(logi.ToList());
        }
        */
        // GET: Log/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logi logi = db.Logi.Find(id);
            if (logi == null)
            {
                return HttpNotFound();
            }
            return View(logi);
        }

        // GET: Log/Create
        public ActionResult Create()
        {
            ViewBag.HenkiloID = new SelectList(db.Henkilot, "HenkiloID", "Etunimi");
            ViewBag.KirjaajaID = new SelectList(db.Logi, "HID", "Etunimi");
            ViewBag.LaiteID = new SelectList(db.Laitteet, "LaiteID", "Sarjanumero");
            ViewBag.TilaID = new SelectList(db.Tilat, "TilaID", "Tarkennus");
            return View();
        }

        // POST: Log/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LogiID,SijaintiID,PaikkaID,KirjaajaID,Kirjattusisään,HenkiloID,LaiteID,TilaID")] Logi logi)
        {
            if (ModelState.IsValid)
            {
                db.Logi.Add(logi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HenkiloID = new SelectList(db.Henkilot, "HenkiloID", "Etunimi", logi.HenkiloID);
            ViewBag.LaiteID = new SelectList(db.Laitteet, "LaiteID", "Sarjanumero", logi.LaiteID);
            ViewBag.TilaID = new SelectList(db.Tilat, "TilaID", "Tarkennus", logi.TilaID);
            return View(logi);
        }

        // GET: Log/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logi logi = db.Logi.Find(id);
            if (logi == null)
            {
                return HttpNotFound();
            }
            ViewBag.HenkiloID = new SelectList(db.Henkilot, "HenkiloID", "Etunimi", logi.HenkiloID);
            ViewBag.LaiteID = new SelectList(db.Laitteet, "LaiteID", "Sarjanumero", logi.LaiteID);
            ViewBag.TilaID = new SelectList(db.Tilat, "TilaID", "Tarkennus", logi.TilaID);
            return View(logi);
        }

        // POST: Log/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LogiID,SijaintiID,PaikkaID,KirjaajaID,Kirjattusisään,HenkiloID,LaiteID,TilaID")] Logi logi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HenkiloID = new SelectList(db.Henkilot, "HenkiloID", "Etunimi", logi.HenkiloID);
            ViewBag.LaiteID = new SelectList(db.Laitteet, "LaiteID", "Sarjanumero", logi.LaiteID);
            ViewBag.TilaID = new SelectList(db.Tilat, "TilaID", "Tarkennus", logi.TilaID);
            return View(logi);
        }

        // GET: Log/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logi logi = db.Logi.Find(id);
            if (logi == null)
            {
                return HttpNotFound();
            }
            return View(logi);
        }

        // POST: Log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Logi logi = db.Logi.Find(id);
            db.Logi.Remove(logi);
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
