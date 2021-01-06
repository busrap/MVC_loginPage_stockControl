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
    public class HomeController : Controller
    {
     
        public ActionResult Index()
        {
            ViewBag.aktifKullanici = HttpContext.Application["AktifKullanici"];
            ViewBag.toplamZiyaretci = HttpContext.Application["ToplamZiyaretci"];
          
            return View();
        }
        public ActionResult Sepetim()
        {
            
            List<Urunler> urunler = new List<Urunler>();
            if (Session["AktifSepet"]!=null)
            {
                Sepet s = (Sepet)Session["AktifSepet"];
                urunler = s.Urunler;
            }
      
            return View(urunler);
        }

     
    }
}