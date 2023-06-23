using OtelMvcProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OtelMvcProje.Controllers
{
    [Authorize]
    public class MisafirController : Controller
    {
        DbOtelEntities db = new DbOtelEntities();

        public ActionResult Index()
        {
            var misafirmail = (string)Session["Mail"];
            var misafirbilgi = db.TblYeniKayit.Where(x => x.Mail == misafirmail).FirstOrDefault();
            return View(misafirbilgi);

        }
        public ActionResult Rezervasyonlarim()
        {
            var misafirmail = (string)Session["Mail"];
            var misafirid = db.TblYeniKayit.Where(x => x.Mail == misafirmail).Select(x => x.ID).FirstOrDefault();
            ViewBag.a = misafirid;
            var degerler = db.TblRezervasyon.Where(x => x.Misafir == misafirid).ToList();
            return View(degerler);
        }
        public ActionResult MisafirBilgiGuncelle(TblYeniKayit p)
        {
            var misafir = db.TblYeniKayit.Find(p.ID);
            misafir.AdSoyad = p.AdSoyad;
            misafir.Sifre = p.Sifre;
            misafir.Telefon = p.Telefon;
            misafir.Mail = p.Mail;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "AnaSayfa");
        }
        public ActionResult GelenMesajlar()
        {
            var misafirmail = (string)Session["Mail"];
            var mesajlar = db.TblMesaj2.Where(x => x.Alici == misafirmail).ToList();
            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var misafirmail = (string)Session["Mail"];
            var mesajlar = db.TblMesaj2.Where(x => x.Gonderen == misafirmail).ToList();
            return View(mesajlar);
        }
    }
}