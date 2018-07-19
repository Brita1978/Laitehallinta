using Laitehallinta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laitehallinta.Controllers
{
    public class HakulogController : Controller
    {
        private SeurantaEntities db = new SeurantaEntities();
        // GET: Hakulog
        public ActionResult Index( string searching)
            
        {
            
            return View(db.Logi.Where( i => i.Laitteet.Merkki.Equals(searching) || searching == null).ToList());
        }
    }
}