using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapSatis.Entities
{
    [Table("Sepet")]
    public  class Sepet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual Kitap Kitap { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
