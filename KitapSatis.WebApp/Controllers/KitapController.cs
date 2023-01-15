using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KitapSatis.BusinessLayer;
using KitapSatis.Entities;
using KitapSatis.WebApp.Models;

namespace KitapSatis.WebApp.Controllers
{
    public class KitapController : Controller
    {
        KitapYonetim kitapYonetim = new KitapYonetim();
        KategoriYonetim kategoriYonetim = new KategoriYonetim();

        public ActionResult Index()
        {

            var kitaps = kitapYonetim.ListQueryable().Include("Kategori").OrderByDescending(x => x.Degistirme);
            return View(kitaps.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitap kitap = kitapYonetim.Find(x => x.Id == id);
            if (kitap == null)
            {
                return HttpNotFound();
            }
            return View(kitap);
        }

        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(kategoriYonetim.List(), "Id", "Baslik");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kitap kitap, HttpPostedFileBase KitapImage)
        {
            ModelState.Remove("Olusturma");
            ModelState.Remove("DegTarihi");
            ModelState.Remove("DegKullanici");
            if (ModelState.IsValid)
            {
                kitapYonetim.Insert(kitap);
                return RedirectToAction("Index");
            }

            ViewBag.KategoriId = new SelectList(kategoriYonetim.List(), "Id", "Baslik", kitap.KategoriId);
            return View(kitap);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitap kitap = kitapYonetim.Find(x => x.Id == id);
            if (kitap == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(kategoriYonetim.List(), "Id", "Baslik", kitap.KategoriId);
            return View(kitap);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kitap kitap)
        {
            ModelState.Remove("Olusturma");
            ModelState.Remove("DegTarihi");
            ModelState.Remove("DegKullanici");
            if (ModelState.IsValid)
            {
                Kitap db_kitap = kitapYonetim.Find(x => x.Id == kitap.Id);
                db_kitap.KategoriId = kitap.KategoriId;
                db_kitap.Fiyat = kitap.Fiyat;
                kitapYonetim.Update(db_kitap);
                return RedirectToAction("Index");
            }
            ViewBag.KategoriId = new SelectList(kategoriYonetim.List(), "Id", "Baslik", kitap.KategoriId);
            return View(kitap);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitap kitap = kitapYonetim.Find(x => x.Id == id);
            if (kitap == null)
            {
                return HttpNotFound();
            }
            return View(kitap);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kitap kitap = kitapYonetim.Find(x => x.Id == id);
            kitapYonetim.Delete(kitap);
            return RedirectToAction("Index");
        }

    }    
}
