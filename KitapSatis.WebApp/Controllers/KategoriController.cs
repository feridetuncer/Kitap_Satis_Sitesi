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

namespace KitapSatis.WebApp.Controllers
{
    public class KategoriController : Controller
    {
        KategoriYonetim kategoriYonetim = new KategoriYonetim();

        public ActionResult Index()
        {
            return View(kategoriYonetim.List());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = kategoriYonetim.Find(x=>x.Id==id.Value);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Kategori kategori)
        {
            ModelState.Remove("Olusturma");
            ModelState.Remove("DegTarihi");
            ModelState.Remove("DegKullanici");
            if (ModelState.IsValid)
            {
                kategoriYonetim.Insert(kategori);
                return RedirectToAction("Index");
            }

            return View(kategori);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = kategoriYonetim.Find(x => x.Id == id.Value);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kategori kategori)
        {
            ModelState.Remove("Olusturma");
            ModelState.Remove("DegTarihi");
            ModelState.Remove("DegKullanici");
            if (ModelState.IsValid)
            {
                Kategori kat = kategoriYonetim.Find(x => x.Id == kategori.Id);
                kat.Baslik = kategori.Baslik;
                kat.Aciklama = kategori.Aciklama;
                kategoriYonetim.Update(kategori);
                return RedirectToAction("Index");
            }
            return View(kategori);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = kategoriYonetim.Find(x => x.Id == id.Value);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategori kategori = kategoriYonetim.Find(x => x.Id == id);
            kategoriYonetim.Delete(kategori);
            return RedirectToAction("Index");
        }

        
    }
}
