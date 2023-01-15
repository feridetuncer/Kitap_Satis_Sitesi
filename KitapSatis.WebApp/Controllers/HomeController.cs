using KitapSatis.BusinessLayer;
using KitapSatis.BusinessLayer.Results;
using KitapSatis.Entities;
using KitapSatis.Entities.Messages;
using KitapSatis.Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KitapSatis.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private KategoriYonetim katYonetim = new KategoriYonetim();
        private KitapYonetim kitapYonetim = new KitapYonetim();
        private KSKullaniciYönetim kulYonetim = new KSKullaniciYönetim();
        // GET: Home
        public ActionResult Index()
        {
            
         return View(kitapYonetim.ListQueryable().OrderByDescending(x=>x.Degistirme).ToList());
        }

        public ActionResult Kategoriler(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Kategori kat = katYonetim.Find(x=> x.Id==id.Value);

            if (kat == null)
            {
                return HttpNotFound();
            }
            return View("Index" ,kat.Kitaplar);
        }

        public ActionResult CokSatanlar()
        {
            return View("Index", kitapYonetim.ListQueryable().OrderByDescending(x => x.Degistirme).ToList());
        }

        public ActionResult ShowProfile()
        {
            Kullanici currentuser = Session["login"] as Kullanici;
            KSKullaniciYönetim ky = new KSKullaniciYönetim();
            BusinessLayerResult<Kullanici> res = ky.GetUserById(currentuser.Id);
            if (res.Hatalar.Count>0)
            {

            }
            return View(res.Sonuc);
        }

        public ActionResult EditProfile()
        {
            Kullanici currentuser = Session["login"] as Kullanici;
            
            BusinessLayerResult<Kullanici> res = kulYonetim.GetUserById(currentuser.Id);
           
            return View(res.Sonuc);
        }
        [HttpPost]
        public ActionResult EditProfile(Kullanici model, HttpPostedFileBase ProfileImage)
        {
            return View();
        }

        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(GirisViewModel model)
        {
            if (ModelState.IsValid)
            {
               
               BusinessLayerResult<Kullanici> res= kulYonetim.GirisKullanici(model);
               if (res.Hatalar.Count > 0)
               {
                    if (res.Hatalar.Find(x=> x.Kod==HataMesajKodlari.KullaniciAktifDegil)!=null)
                    {
                        ViewBag.SetLink = "http://Home/Aktivasyon/1234-4567-895545";
                    }
                  res.Hatalar.ForEach(x => ModelState.AddModelError("", x.Mesaj));
                  return View(model);
               }
                Session["login"] = res.Sonuc;
                return RedirectToAction("Index");
            }
           
            return View(model);
        }

        public ActionResult UyeOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeOl(UyelikViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                BusinessLayerResult<Kullanici> res = kulYonetim.UyeKullanici(model);

                if (res.Hatalar.Count>0)
                {
                    
                    res.Hatalar.ForEach(x => ModelState.AddModelError("", x.Mesaj));
                    return View(model);
                }
                return RedirectToAction("UyeOlOk");
            }
            return View(model);
        }

        public ActionResult UyeOlOk()
        {
            return View();
        }

        public ActionResult Aktivasyon(Guid aktivasyon_id)
        {
           
           BusinessLayerResult<Kullanici> res= kulYonetim.ActivateKullanici(aktivasyon_id);
            if (res.Hatalar.Count>0)
            {
                TempData["hatalar"] = res.Hatalar;
                return RedirectToAction("AktivasyonIptal");
            }
            return RedirectToAction("AktivasyonOk") ;
        }

        public ActionResult AktivasyonOk()
        {
            return View();
        }

        public ActionResult AktivasyonIptal()
        {
            List<HataMesajObj> hatalar = null;
            if (TempData["hatalar"] !=null)
            {
                hatalar = TempData["hatalar"] as List<HataMesajObj>;
            }
            return View(hatalar);
        }

        public ActionResult Cikis()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}