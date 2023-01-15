using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapSatis.Entities
{
    [Table("Yorumlar")]
    public class Yorum:EntityBase
    {
        [Required, StringLength(300)]
        public string Metin { get; set; }
        public virtual Kitap Kitap { get; set; }
        public virtual Kullanici Kullanici { get; set; }

    }
}
