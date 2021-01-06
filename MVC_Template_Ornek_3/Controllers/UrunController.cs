using MVC_Template_Ornek_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Template_Ornek_3.Controllers
{
    using App_Classes;
    [Authorize]
    public class UrunController : Controller
    {
        ModelContext ctx = new ModelContext();
        public ActionResult Index()
        {
            //List şeklinde tuttuğumuz için @model'de de List<> şeklinde tutacağız(view sayfasında)
            List<Urunler> urunListe = ctx.Urunlers.ToList();
            return View(urunListe); 
        }
        public ActionResult UrunEkle()
        {
            ViewBag.kate = ctx.Kategorilers.ToList();
            ViewBag.teda = ctx.Tedarikcilers.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urunler u)
        {
            ctx.Urunlers.Add(u);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        //Sil butonu tıklandığında id değeri yakalanır
        public ActionResult Sil(int id)
        {
            Urunler u = ctx.Urunlers.FirstOrDefault(x => x.UrunID == id);
            return View(u);
        }
        [HttpPost]
        public ActionResult Sil(Urunler u)
        {
            Urunler urn = ctx.Urunlers.FirstOrDefault(x => x.UrunID == u.UrunID);
            ctx.Urunlers.Remove(urn);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunDetay()
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            string adi = Request.QueryString["adi"].ToString();
            Urunler u = ctx.Urunlers.FirstOrDefault(x => x.UrunID == id);
            return View(u);
        }
        [HttpPost]
        public void SepeteAt(int id)
        {
            Sepet s;
            if (Session["AktifSepet"] == null)
            {
                s = new Sepet();
            }
            else
            {
                 s =(Sepet) Session["AktifSepet"];

            }

         
            Urunler u = ctx.Urunlers.FirstOrDefault(x => x.UrunID == id);
            s.Urunler.Add(u);
            Session["AktifSepet"] = s;
        }




    }
}