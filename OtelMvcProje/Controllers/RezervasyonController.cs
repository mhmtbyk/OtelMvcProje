using OtelMvcProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtelMvcProje.Controllers
{
    public class RezervasyonController : Controller
    {
        // GET: Rezervasyon
        DbOtelEntities db = new DbOtelEntities();
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblRezervasyon p)
        {
            var misafirmail = (string)Session["Mail"];
            var misafirid = db.TblYeniKayit.Where(x => x.Mail == misafirmail).Select(x => x.ID).FirstOrDefault();
            p.Durum = 14;
            p.Misafir = misafirid;
            db.TblRezervasyon.Add(p);
            db.SaveChanges();
            return RedirectToAction("Rezervasyonlarim", "Misafir");
        }
    }
}