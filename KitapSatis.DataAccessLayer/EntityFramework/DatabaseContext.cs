using KitapSatis.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapSatis.DataAccessLayer.EntityFramework
{
    public class DatabaseContext :DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Yorum> Yorumlar{ get; set; }
        public DbSet<Sepet> Sepet { get; set; }
    }
}
