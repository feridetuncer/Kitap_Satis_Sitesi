using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapSatis.Entities
{
    [Table("Kitaplar")]
    public class Kitap:EntityBase
    {
        [DisplayName("Kitap Adı"),Required, StringLength(70)]
        public string KitapAdi { get; set; }
        [DisplayName("Yazar"),Required, StringLength(70)]
        public string Yazar { get; set; }
        [DisplayName("Yayınevi"),Required, StringLength(70)]
        public string Yayinevi { get; set; }
        [DisplayName("Resim"),Required, StringLength(50)]
        public string ResimDosyaAdi { get; set; }
        [DisplayName("Fiyat"),Required, StringLength(70)]
        public string Fiyat { get; set; }
        [DisplayName("Kategori")]
        public int KategoriId { get; set; }
        public virtual List<Yorum> Yorumlar { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual List<Sepet> Sepet { get; set; }

        public Kitap()
        {
            Yorumlar = new List<Yorum>();
            Sepet = new List<Sepet>();
        }
    }
}
