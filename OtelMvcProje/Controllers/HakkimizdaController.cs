using OtelMvcProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtelMvcProje.Controllers
{
    public class HakkimizdaController : Controller
    {
        // GET: Hakkimizda
        DbOtelEntities db = new DbOtelEntities();
        public ActionResult Index()
        {
            var veriler = db.TblHakkimda.ToList();
            return View(veriler);
        }
    }
}