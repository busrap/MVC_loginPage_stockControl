using MVC_Template_Ornek_3.App_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Template_Ornek_3.Controllers
{
    [Authorize]
    public class KullaniciController : Controller
    {
      
        public ActionResult KullaniciIndex()
        {
            MembershipUserCollection users = Membership.GetAllUsers();
            return View(users);
        }

        [AllowAnonymous]
        public ActionResult KullaniciEkle()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult KullaniciEkle(Kullanici k)
        {
            MembershipCreateStatus durum;
            Membership.CreateUser(k.KullaniciAdi, k.Parola,k.Email, k.GizliSoru, k.GizliCevap, true, out durum);
            string mesaj = "";
            switch (durum)
            {
                case MembershipCreateStatus.Success:
                    break;
                case MembershipCreateStatus.InvalidUserName:
                    mesaj += "Gerçersiz kullanıcı adı";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    mesaj += "Geçersiz parola";
                    break;
                case MembershipCreateStatus.InvalidQuestion:
                    mesaj += "Geçersiz gizli soru";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    mesaj += "Geçersiz Gizli Cevap";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    mesaj += "Geçersiz mail adresi";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    mesaj += "Kullanılmış kullanıcı adı";
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    mesaj += "Kullanılmış Email Adresi Girildi.";
                    break;
                case MembershipCreateStatus.UserRejected:
                    mesaj += "Kullanıcı engel hatası";
                    break;
                case MembershipCreateStatus.InvalidProviderUserKey:
                    mesaj += "Geçersiz kullanıcı key hatası";
                    break;
                case MembershipCreateStatus.DuplicateProviderUserKey:
                    mesaj += "Kullanılmış kullanıcı key hatası";
                    break;
                case MembershipCreateStatus.ProviderError:
                    mesaj += "Üye yönetimi sağlayıcısı hatası";
                    break;
                default:
                    break;
            }
            ViewBag.Mesaj = mesaj;
            if (durum == MembershipCreateStatus.Success)
            {
                return RedirectToAction("KullaniciIndex");
            }
            else
                return View();
        }
        [Authorize(Roles="Admin")]
        public ActionResult RolAta()
        {
            ViewBag.rolu = Roles.GetAllRoles().ToList();
            ViewBag.kullanicilar = Membership.GetAllUsers();
            return View();
        }
        [Authorize(Roles="Admin")]
        [HttpPost]
        public ActionResult RolAta(string KullaniciAdi,string RolAdi )
        {
            Roles.AddUserToRole(KullaniciAdi, RolAdi);
            return RedirectToAction("KullaniciIndex");
        }
        [HttpPost]
        public string KullaniciUyeRolleri(string kullaniciAdiPrm)
        {
            List<string> roller= Roles.GetRolesForUser(kullaniciAdiPrm).ToList();
            string rol = "";
            foreach (string item in roller)
            {
                rol += item + "-";
            }
            rol = rol.Remove(rol.Length - 1, 1);

            return rol;
        }
    }
}