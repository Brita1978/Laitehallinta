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
    
    public class HakuController : Controller
    {
        private SeurantaEntities db = new SeurantaEntities();
        // GET: Haku
        public ActionResult Index(string searching)
        {
            return View(db.Henkilot.Where(x => x.Etunimi.StartsWith(searching)|| searching == null).ToList());
        }
    }
}