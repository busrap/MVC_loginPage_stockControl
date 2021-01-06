using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Template_Ornek_3.Controllers
{
    [Authorize]
    public class RolController : Controller
    {
      
        public ActionResult RolIndex()
        {
            List<string> roller = Roles.GetAllRoles().ToList();
            return View(roller);
        }

        public ActionResult RolEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RolEkle(string RolAdi)
        {

            Roles.CreateRole(RolAdi);
            return RedirectToAction("RolIndex");

        }
    }
}