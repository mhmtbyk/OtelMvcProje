using OtelMvcProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtelMvcProje.Controllers
{
    public class KayitController : Controller
    {
        // GET: Kayit
        DbOtelEntities db = new DbOtelEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index(TblYeniKayit p)
        {
            db.TblYeniKayit.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index", "Login");
        }
    }
}