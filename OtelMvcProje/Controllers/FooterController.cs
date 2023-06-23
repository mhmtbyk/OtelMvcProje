using OtelMvcProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtelMvcProje.Controllers
{
    public class FooterController : Controller
    {
        // GET: Footer
        DbOtelEntities db = new DbOtelEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialFooter()
        {
            var doluoda = db.TblOda.Where(x => x.Durum != 1).Count();
            ViewBag.d = doluoda;
            var bosoda = db.TblOda.Where(x => x.Durum == 1).Count();
            ViewBag.b = bosoda;
            return PartialView();
        }
        public PartialViewResult PartialSosyalMedya()
        {
            return PartialView();
        }
    }
}