using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using KitapSatis.Entities;

namespace KitapSatis.DataAccessLayer.EntityFramework
{
   public class Baslangic:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            Kullanici admin = new Kullanici()
            {
                Ad = "Feride",
                Soyad = "Tuncer",
                KullaniciAdi = "feridetuncer",
                Email = "feridetuncer@mail.com",
                Sifre = "12345",
                AktifMi = true,
                AdminMi = true,
                Aktivasyon = Guid.NewGuid(),
                Olusturma = DateTime.Now,
                Degistirme = DateTime.Now.AddMinutes(5),
                DegKullanici = "feridetuncer"
            };

            Kullanici standart = new Kullanici()
            {
                Ad = "Ahmet",
                Soyad = "Tuncer",
                KullaniciAdi = "ahmettuncer",
                Email = "ahmettuncer@mail.com",
                Sifre = "54321",
                AktifMi = true,
                AdminMi = false,
                Aktivasyon = Guid.NewGuid(),
                Olusturma = DateTime.Now.AddHours(1),
                Degistirme = DateTime.Now.AddMinutes(65),
                DegKullanici = "feridetuncer"
            };
            context.Kullanicilar.Add(admin);
            context.Kullanicilar.Add(standart);
            context.SaveChanges();

            //fake kategori ekleme
            for (int i = 0; i < 10; i++)
            {
                Kategori kat = new Kategori()
                {
                    Baslik=FakeData.PlaceData.GetStreetName(),
                    Aciklama=FakeData.PlaceData.GetAddress(),
                    Olusturma=DateTime.Now,
                    Degistirme=DateTime.Now,
                    DegKullanici="feridetuncer"
                };

            }
        }
    }
}
