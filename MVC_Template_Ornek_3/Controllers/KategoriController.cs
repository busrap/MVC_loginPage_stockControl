using MVC_Template_Ornek_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Template_Ornek_3.Controllers
{
    [Authorize]
    public class KategoriController : Controller
    {
        ModelContext ctx = new ModelContext();
        public ActionResult KategoriIndex()
        {
            List<Kategoriler> ktg = ctx.Kategorilers.ToList();
            return View(ktg);
        }
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategoriler k)
        {
            ctx.Kategorilers.Add(k);
            ctx.SaveChanges();
            return RedirectToAction("KategoriIndex");
        }
        [HttpPost]
        public void KategoriSil(int id)
        {
            Kategoriler k = ctx.Kategorilers.FirstOrDefault(x => x.KategoriID == id);
            ctx.Kategorilers.Remove(k);
            ctx.SaveChanges();
             
        }
    }
}