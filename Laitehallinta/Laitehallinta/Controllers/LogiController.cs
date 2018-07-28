using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Laitehallinta.Models;
using Laitehallinta.Utilities;
using Newtonsoft.Json;

namespace Laitehallinta.Controllers
{
    public class LogiController : Controller
    {
        private SeurantaEntities db = new SeurantaEntities();

        // GET: Logi
        public ActionResult Index(string searching)

        {
            return View(db.Logi.Where(i => i.Laitteet.Sarjanumero.Equals(searching) || searching == null).ToList());
        }
        //{
        //    var logi = db.Logi.Include(l => l.Henkilot).Include(l => l.Laitteet).Include(l => l.Tilat);
        //    return View(logi.ToList());
        //}

        // GET: Logi/Details/5
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

        // GET: Logi/Create
        public ActionResult Create()
        {
            ViewBag.HenkiloID = new SelectList(db.Henkilot, "HenkiloID", "Etunimi");
            ViewBag.LaiteID = new SelectList(db.Laitteet, "LaiteID", "Sarjanumero");
            ViewBag.TilaID = new SelectList(db.Tilat, "TilaID", "Tarkennus");

            return View();
        }

        // POST: Logi/Create
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

        // GET: Logi/Edit/5
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

        // POST: Logi/Edit/5
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

        // GET: Logi/Delete/5
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

        // POST: Logi/Delete/5
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


        //public ActionResult TestiListaus()
        //{
        //    List<LaiteTallennusViewModel> model = new List<LaiteTallennusViewModel>();

        //    SeurantaEntities entities = new SeurantaEntities();
        //    try
        //    {
        //        List<Logi> logs = entities.Logi.ToList();

        //        CultureInfo fiFi = new CultureInfo("fi-FI");

        //        // muodostetaan näkymämalli tietokannan rivien pohjalta
        //        foreach (Logi log in logs)
        //        {
        //            LaiteTallennusViewModel view = new LaiteTallennusViewModel();
        //            view.LogiID = log.LogiID;
        //            view.Tarkennus = log.Tilat.Tarkennus;
        //            view.Merkki = log.Laitteet.Sarjanumero;
        //            //view.AssetCode = log.Assets.Code;
        //            //view.AssetName = log.Assets.Type + ": " + asset.Assets.Model;
        //            view.Kirjattusisään = log.Kirjattusisään.Value;

        //            model.Add(view);
        //        }
        //    }
        //    finally
        //    {
        //        entities.Dispose();
        //    }

        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        //AssetController.cs - LAITTEIDEN TALLENTAMINEN (SQL) TIETOKANTAAN
        public JsonResult LogiTallennus()
        {
            string json = Request.InputStream.ReadToEnd(); //WebUtilities -luokka, laajennusmetodi
            LaiteTallennusViewModel inputData =
                JsonConvert.DeserializeObject<LaiteTallennusViewModel>(json);

            bool success = false;
            string error = "";

            SeurantaEntities entities = new SeurantaEntities();

            try
            {
                //haetaan ensin paikan id-numero koodin perusteella:
                int tilaId = (from t in entities.Tilat
                              where t.Tarkennus == inputData.Tarkennus
                              select t.TilaID).FirstOrDefault();

                //haetaan laitteen id-numero koodin perusteella:
                int laiteId = (from l in entities.Laitteet
                               where l.Sarjanumero == inputData.Merkki
                               select l.LaiteID).FirstOrDefault();

                //haetaan kirjaaja henkilön id-numero koodin perusteella:
                //int henkiloId = (from h in entities.Henkilot
                //               where h.Etunimi == inputData.Etunimi
                //               select h.HenkiloID).FirstOrDefault();

                if ((tilaId > 0) && (tilaId > 0) /*&& (henkiloId > 0)*/)
                {
                    //tallennetaan uusi rivi aikaleiman kanssa kantaan:
                    Logi newEntry = new Logi();
                    newEntry.PaikkaID = tilaId;
                    newEntry.SijaintiID = laiteId;
                    //newEntry.KirjaajaID = henkiloId;
                    newEntry.Kirjattusisään = DateTime.Now;

                    entities.Logi.Add(newEntry);

                    entities.SaveChanges();

                    success = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.GetType().Name + ": " + ex.Message;
            }
            finally
            {
                entities.Dispose();
            }

            //palautetaan JSON-muotoinen tulos kutsujalle
            var result = new { success = success, error = error };
            return Json(result);
        }

        public ActionResult TestiListaus()
        {
            List<LaiteTallennusViewModel> model = new List<LaiteTallennusViewModel>();

            SeurantaEntities entities = new SeurantaEntities();

            try
            {
                List<Logi> logs = entities.Logi.ToList();

                CultureInfo fiFi = new CultureInfo("fi-FI");

                // muodostetaan näkymämalli tietokannan rivien pohjalta
                foreach (Logi log in logs)
                {
                    LaiteTallennusViewModel view = new LaiteTallennusViewModel();
                    view.LogiID = log.LogiID;
                    view.Kirjattusisään = log.Kirjattusisään.Value;

                    view.TilaID = log.Tilat?.TilaID;
                    view.Tarkennus = log.Tilat?.Tarkennus;

                    view.LaiteID = log.Laitteet?.LaiteID;
                    view.Merkki = log.Laitteet?.Merkki;
                    view.Sarjanumero = log.Laitteet?.Sarjanumero;
                    view.Malli = log.Laitteet?.Malli;
                    view.Muuta = log.Laitteet?.Muuta;

                    view.HenkiloID = log.Henkilot?.HenkiloID;
                    view.Etunimi = log.Henkilot?.Etunimi;
                    //view.Sukunimi = log.Henkilot?.Sukunimi;
                    view.EtunimiH = log.Henkilot?.Etunimi;
                    view.SukunimiH = log.Henkilot?.Sukunimi;
                    view.FullNameH = log.Henkilot?.Etunimi + " " + log.Henkilot?.Sukunimi;
                    ViewBag.FullNameH = new SelectList((from h in db.Henkilot select new { HenkiloID = h.HenkiloID, FullNameH = h.Etunimi + " " + h.Sukunimi }), "HenkiloID", "FullNameH", null);

                    //view.SijaintiID = log.SijaintiID;
                    //view.PaikkaID = log.PaikkaID;
                    //view.KirjaajaID = log.KirjaajaID;

                    model.Add(view);
                }
            }
            finally
            {
                entities.Dispose();
            }

            return View(model);
            //return View(db.Logi.Where(i => i.Laitteet.Sarjanumero.Equals(searching) || searching == null).ToList());
        }

        // GET: LaiteKirjausEdit
        public ActionResult LaiteKirjausEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logi log = db.Logi.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }

            LaiteTallennusViewModel view = new LaiteTallennusViewModel();
            view.LogiID = log.LogiID;
            view.Kirjattusisään = log.Kirjattusisään.Value;

            view.TilaID = log.Tilat?.TilaID;
            view.Tarkennus = log.Tilat?.Tarkennus;
            ViewBag.Tarkennus = new SelectList((from t in db.Tilat select new { TilaID = t.TilaID, Tarkennus = t.Tarkennus }), "TilaID", "Tarkennus", view.TilaID);

            view.LaiteID = log.Laitteet?.LaiteID;
            view.Merkki = log.Laitteet?.Merkki;
            view.Sarjanumero = log.Laitteet?.Sarjanumero;
            view.Malli = log.Laitteet?.Malli;
            view.Muuta = log.Laitteet?.Muuta;
            ViewBag.Sarjanumero = new SelectList((from l in db.Laitteet select new { LaiteID = l.LaiteID, Sarjanumero = l.Sarjanumero }), "LaiteID", "Sarjanumero", view.LaiteID);

            view.HenkiloID = log.Henkilot?.HenkiloID;
            view.Etunimi = log.Henkilot?.Etunimi;
            view.Sukunimi = log.Henkilot?.Sukunimi;
            ViewBag.FullNameH = new SelectList((from h in db.Henkilot select new { HenkiloID = h.HenkiloID, FullNameH = h.Etunimi + " " + h.Sukunimi }), "HenkiloID", "FullNameH", view.HenkiloID);
            ViewBag.Etunimi = new SelectList((from h in db.Henkilot select new { HenkiloID = h.HenkiloID, Etunimi= h.Etunimi}), "HenkiloID", "Etunimi", view.HenkiloID);

            //view.KirjaajaID = log.Henkilot?.Etunimi + " " + log.Henkilot?.Sukunimi;     
            //view.SijaintiID = log.SijaintiID;
            //view.PaikkaID = log.PaikkaID;
            //view.KirjaajaID = log.KirjaajaID;

            return View(view);
        }

        // POST: LaiteKirjausEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LaiteKirjausEdit(LaiteTallennusViewModel model)
        {
            Logi log = db.Logi.Find(model.LogiID);
            //log.Kirjattusisään = model.Kirjattusisään.GetValueOrDefault();
            log.Kirjattusisään = DateTime.Now;

            int henkiloId = int.Parse(model.Etunimi);
            if (henkiloId > 0)
            {
                Henkilot hlo = db.Henkilot.Find(henkiloId);
                log.HenkiloID = hlo.HenkiloID;
            }

            int tilaId = int.Parse(model.Tarkennus);
            if (tilaId > 0)
            {
                Tilat til = db.Tilat.Find(tilaId);
                log.TilaID = til.TilaID;
            }

            int laiteId = int.Parse(model.Sarjanumero);
            if (laiteId > 0)
            {
                Laitteet lai = db.Laitteet.Find(laiteId);
                log.LaiteID = lai.LaiteID;
            }
   
            ViewBag.Sarjanumero = new SelectList((from l in db.Laitteet select new { LaiteID = l.LaiteID, Sarjanumero = l.Sarjanumero }), "LaiteID", "Sarjanumero", log.LaiteID);
            ViewBag.Tarkennus = new SelectList((from t in db.Tilat select new { TilaID = t.TilaID, Tarkennus = t.Tarkennus }), "TilaID", "Tarkennus", log.TilaID);
            ViewBag.FullNameH = new SelectList((from h in db.Henkilot select new { HenkiloID = h.HenkiloID, FullNameH = h.Etunimi + " " + h.Sukunimi }), "HenkiloID", "FullNameH", log.HenkiloID);
            ViewBag.Etunimi = new SelectList((from h in db.Henkilot select new { HenkiloID = h.HenkiloID, Etunimi = h.Etunimi }), "HenkiloID", "Etunimi", log.HenkiloID);

            db.SaveChanges();
            return RedirectToAction("TestiListaus");
        }


        // GET: LaiteKirjaus
        public ActionResult LaiteKirjaus()
        {
            SeurantaEntities db = new SeurantaEntities();

            LaiteTallennusViewModel model = new LaiteTallennusViewModel();

            ViewBag.Sarjanumero = new SelectList((from l in db.Laitteet select new { LaiteID = l.LaiteID, Sarjanumero = l.Sarjanumero }), "LaiteID", "Sarjanumero", null);
            ViewBag.Tarkennus = new SelectList((from t in db.Tilat select new { TilaID = t.TilaID, Tarkennus = t.Tarkennus }), "TilaID", "Tarkennus", null);
            ViewBag.FullNameH = new SelectList((from h in db.Henkilot select new { HenkiloID = h.HenkiloID, FullNameH = h.Etunimi + " " + h.Sukunimi }), "HenkiloID", "FullNameH", null);
            ViewBag.Etunimi = new SelectList((from h in db.Henkilot select new { HenkiloID = h.HenkiloID, Etunimi = h.Etunimi}), "HenkiloID", "Etunimi", null);

            return View(model);
        }

        // POST: LaiteKirjaus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LaiteKirjaus(LaiteTallennusViewModel model)
        {
            SeurantaEntities db = new SeurantaEntities();

            Logi log = new Logi();
            log.LogiID = model.LogiID;
            log.Kirjattusisään = DateTime.Now;

            db.Logi.Add(log);

            int henkiloId = int.Parse(model.Etunimi);
            if (henkiloId > 0)
            {
                Henkilot hlo = db.Henkilot.Find(henkiloId);
                log.HenkiloID = hlo.HenkiloID;
            }

            int tilaId = int.Parse(model.Tarkennus);
            if (tilaId > 0)
            {
                Tilat til = db.Tilat.Find(tilaId);
                log.TilaID = til.TilaID;
            }

            int laiteId = int.Parse(model.Sarjanumero);
            if (laiteId > 0)
            {
                Laitteet lai = db.Laitteet.Find(laiteId);
                log.LaiteID = lai.LaiteID;
            }

            ViewBag.Sarjanumero = new SelectList((from l in db.Laitteet select new { LaiteID = l.LaiteID, Sarjanumero = l.Sarjanumero }), "LaiteID", "Sarjanumero", null);
            ViewBag.Tarkennus = new SelectList((from t in db.Tilat select new { TilaID = t.TilaID, Tarkennus = t.Tarkennus }), "TilaID", "Tarkennus", null);
            ViewBag.FullNameH = new SelectList((from h in db.Henkilot select new { HenkiloID = h.HenkiloID, FullNameH = h.Etunimi + " " + h.Sukunimi }), "HenkiloID", "FullNameH", null);
            ViewBag.Etunimi = new SelectList((from h in db.Henkilot select new { HenkiloID = h.HenkiloID, Etunimi = h.Etunimi}), "HenkiloID", "Etunimi", null);

            try
            {
                db.SaveChanges();
            }

            catch (Exception ex)
            {
            }

            return RedirectToAction("TestiListaus");
        }

    }
}
