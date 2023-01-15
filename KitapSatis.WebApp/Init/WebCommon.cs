using KitapSatis.Common;
using KitapSatis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitapSatis.WebApp.Init
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUsername()
        {
            if (HttpContext.Current.Session["login"] != null)
            {
                Kullanici kullanici = HttpContext.Current.Session["login"] as Kullanici;
                return kullanici.KullaniciAdi;
            }

            return "system";
        }

       
    }
}