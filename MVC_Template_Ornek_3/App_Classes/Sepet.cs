using MVC_Template_Ornek_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Template_Ornek_3.App_Classes
{
    public class Sepet
    {
        //Sepetitmiz ürünler tipinde nesneler barındıracak
        private  List<Urunler> urunler = new List<Urunler>();

        public List<Urunler> Urunler
        {
            get { return urunler; }
            set { urunler = value; }
        }

    }
}