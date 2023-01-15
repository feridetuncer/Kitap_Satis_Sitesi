using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapSatis.Entities
{
    [Table("Kullanicilar")]
    public class Kullanici:EntityBase
    {
        [StringLength(25)]
        public string Ad { get; set; }
        [StringLength(25)]
        public string Soyad { get; set; }
        [Required,StringLength(25)]
        public string KullaniciAdi { get; set; }
        [Required, StringLength(70)]
        public string Email { get; set; }
        [Required, StringLength(25)]
        public string Sifre { get; set; }
        [StringLength(50)]
        public string ResimDosyaAdi { get; set; }
        public bool AktifMi { get; set; }
        [Required]
        public Guid Aktivasyon { get; set; }
        public bool AdminMi { get; set; }
        public virtual List<Yorum> Yorumlar { get; set; }
        public virtual List<Sepet> Sepet { get; set; }
     
    }
}
