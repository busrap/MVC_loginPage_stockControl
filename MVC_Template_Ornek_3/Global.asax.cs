using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Template_Ornek_3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        //proje ilk çalıştığında ilk çalışan bölüm Global.asax bölümüdür.aşağıda ki yapılan işlemler ile site içerisinde ki toplam aktif kullanıcı sayası görüntülenecek.
        protected void Session_Start()
        {
            if (Application["AktifKullanici"]==null)
            {
                int sayac = 1;
                Application["AktifKullanici"] = sayac;
            }
            else
            {
                int sayac = (int)Application["AktifKullanici"];
                sayac++;
                Application["AktifKullanici"] = sayac;
            }
            //Bu kontrol ile "siteyi toplamda kaç kullanıcı ziyaret etmiş" kontrolü sağlandı
            if (Application["ToplamZiyaretci"]==null)
            {
                int sayac = 1;
                Application["ToplamZiyaretci"] = sayac;

            }
            else
            {
                int sayac = (int)Application["ToplamZiyaretci"];
                sayac++;
                Application["ToplamZiyaretci"] = sayac;
            }

        }
        protected void Session_End()
        {
            int sayac = (int)Application["AktifKullanici"];
            sayac--;
            Application["AktifKullanici"] = sayac;

        }
    }
}
