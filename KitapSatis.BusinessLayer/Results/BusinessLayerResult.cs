using KitapSatis.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapSatis.BusinessLayer.Results
{
    public class BusinessLayerResult<T> where T:class
    {
        public List<HataMesajObj> Hatalar { get; set; }
        public T Sonuc { get; set; }

        public BusinessLayerResult()
        {
            Hatalar = new List<HataMesajObj>();
        }
        public void HataEkle(HataMesajKodlari kod, string mesaj)
        {
            Hatalar.Add(new HataMesajObj() {Kod=kod, Mesaj=mesaj});
        }
    }
}
