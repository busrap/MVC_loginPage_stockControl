using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Template_Ornek_3.Controllers
{
    using App_Classes;
    using System.Web.Security;
    [Authorize]
    public class UyeController : Controller
    {

        [AllowAnonymous]
        public ActionResult GirisYap()
        {
            return View();
        }


        [HttpPost]

        [AllowAnonymous]
        
        public ActionResult GirisYap(Kullanici k,string Hatirla)
        {
            bool sonuc=Membership.ValidateUser(k.KullaniciAdi, k.Parola);
            if (sonuc)
            {
                if (Hatirla == "on")
                    FormsAuthentication.RedirectFromLoginPage(k.KullaniciAdi, true);
                else
                
                    FormsAuthentication.RedirectFromLoginPage(k.KullaniciAdi, false);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.Msj = "Kullanıcı adı veya parola hatalı";
                return View();

            }

           

        }

     
        [AllowAnonymous]

       
        public ActionResult CookieDurum()
        {
            //Browser'da cookies açıkmı kapalımı olduğunu kontrol edebilmek için bir test Cookisi oluşruyoruz
            HttpCookie ck = new HttpCookie("test", "deger");
            ck.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(ck);
            return RedirectToAction("CookieOku");
        }
        [AllowAnonymous]
        public ActionResult CookieOku()
        {
            //Eğer oluşturduğumuz cookie(test isimli cookie),cookie sayfasında varsa geriye giriş yap view'ı dönecek eğer yoksa bu action için oluşturduğum varsayılan cookie kapalı view'ı dönecek
            if (Request.Cookies["test"] != null)
            {
                
                return RedirectToAction("GirisYap");
              
            }
            else
               
            return View();
        }

        public ActionResult CikisYap()
        {
         
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap");
        }


        [AllowAnonymous]
        public ActionResult ParolamiUnuttum()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ParolamiUnuttum(Kullanici k)
        {
            MembershipUser mu = Membership.GetUser(k.KullaniciAdi);
            if (mu.PasswordQuestion==k.GizliSoru)
            {
                string pwd = mu.ResetPassword(k.GizliCevap);
                mu.ChangePassword(pwd, k.Parola);
                return RedirectToAction("GirisYap");
            }
            else
            {
                ViewBag.msj = "Girilen Bilgiler Yanlış!";
                return View();
            }
        }
    }
}