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
    [Table("Kategoriler")]
    public class Kategori:EntityBase
    {
        [DisplayName("Başlık"),Required, StringLength(50)]
        public string Baslik { get; set; }
        [DisplayName("Açıklama"), StringLength(150)]
        public string Aciklama { get; set; }
        public virtual List<Kitap> Kitaplar { get; set; }

        public Kategori()
        {
            Kitaplar = new List<Kitap>();
        }
    }
}
