using MVC_Template_Ornek_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Template_Ornek_3.Controllers
{
    [Authorize]
    public class TedarikciController : Controller
    {
        ModelContext ctx = new ModelContext();
        public ActionResult TedarikciIndex()
        {
            List<Tedarikciler> data = ctx.Tedarikcilers.ToList();
            return View(data);
        }
        [HttpPost]
        public string TedarikciSil(int id)
        {
            Tedarikciler td = ctx.Tedarikcilers.FirstOrDefault(x => x.TedarikciID == id);
            ctx.Tedarikcilers.Remove(td);
            try
            {
                ctx.SaveChanges();
                return "başarılı";
            }
            catch (Exception)
            {

                return "hata";
            }

        }
    }
}