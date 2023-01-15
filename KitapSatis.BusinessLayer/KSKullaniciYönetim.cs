using KitapSatis.BusinessLayer.Abstract;
using KitapSatis.BusinessLayer.Results;
using KitapSatis.Common.Helpers;
using KitapSatis.DataAccesLayer.EntityFramework;
using KitapSatis.Entities;
using KitapSatis.Entities.Messages;
using KitapSatis.Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapSatis.BusinessLayer
{
    public class KSKullaniciYönetim : ManagerBase<Kullanici>
    {

        public BusinessLayerResult<Kullanici> UyeKullanici(UyelikViewModel data)
        {
          Kullanici kullanici = Find(x => x.KullaniciAdi == data.KullaniciAdi || x.Email==data.EMail);
            BusinessLayerResult<Kullanici> layerResult = new BusinessLayerResult<Kullanici>();

            if (kullanici != null)
            {
                if (kullanici.KullaniciAdi==data.KullaniciAdi)
                {
                    layerResult.HataEkle(HataMesajKodlari.KullaniciAdiKullaniliyor, "Kullanıcı adı kayıtlı");
                }
                if (kullanici.Email == data.EMail)
                {
                    layerResult.HataEkle(HataMesajKodlari.EMailAdresiKullaniliyor, "E-posta adresi kayıtlı");
                }
            }
            else
            {
                int dbResult =Insert(new Kullanici()
                {
                    KullaniciAdi = data.KullaniciAdi,
                    Email = data.EMail,
                    Sifre = data.Sifre,
                    AktifMi = false,
                    AdminMi = false,
                    Aktivasyon = Guid.NewGuid()
                   

                });
                if (dbResult>0)
                {
                    layerResult.Sonuc=Find(x => x.Email == data.EMail && x.KullaniciAdi == data.KullaniciAdi);
                    string siteUrl = ConfigHelper.Get<string>("SiteRootUrl");
                    string activateUrl = $"{siteUrl}/Home/Aktivasyon/{layerResult.Sonuc.Aktivasyon}";
                    string body = $"Merhaba {layerResult.Sonuc.KullaniciAdi};<br> <br> Hesabınızı aktifleştirmek için <a href='{activateUrl}' target='_blank' >tıklayın </a> ";
                    MailHelper.SendMail(body, layerResult.Sonuc.Email,"Kitap Satış Hesap Aktivasyonu");
                }
            }
            return layerResult;
        }

        public BusinessLayerResult<Kullanici> GetUserById(int id)
        {
            BusinessLayerResult<Kullanici> res = new BusinessLayerResult<Kullanici>();
            res.Sonuc = Find(x => x.Id == id);
            if (res.Sonuc==null)
            {
                res.HataEkle(HataMesajKodlari.KullaniciBulunamadi, "Kullanıcı bulunamadı.");
            }
            return res;
        }

        public BusinessLayerResult<Kullanici> GirisKullanici(GirisViewModel data)
        {
            
            BusinessLayerResult<Kullanici> res = new BusinessLayerResult<Kullanici>();
             res.Sonuc=Find(x => x.KullaniciAdi == data.KullaniciAdi && x.Sifre == data.Sifre);
            
            if (res.Sonuc != null)
            {
                if (!res.Sonuc.AktifMi)
                {
                    res.HataEkle(HataMesajKodlari.KullaniciAktifDegil, "Kullanıcı aktifleştirilmemiştir.Lütfen mailinizi kontrol ediniz.");
                }
            }
            else
            {
                res.HataEkle(HataMesajKodlari.KullaniciAdiVeyaSifreYanlis,"Kullanıcı adı veya şifre yanlış.");
            }
            return res;
        }

        

        public BusinessLayerResult<Kullanici> ActivateKullanici(Guid aktivasyon_id)
        {
            BusinessLayerResult<Kullanici> res = new BusinessLayerResult<Kullanici>();
            Kullanici kullanici =Find(x => x.Aktivasyon==aktivasyon_id);
            if (res.Sonuc!=null)
            {
                if (res.Sonuc.AktifMi)
                {
                    res.HataEkle(HataMesajKodlari.KullaniciZatenAktif, "Kullanıcı zaten aktifleştirilmiştir.");
                    return res;
                }
                res.Sonuc.AktifMi = true;
                Update(res.Sonuc);
            }
            else
            {
                res.HataEkle(HataMesajKodlari.AktivasyonIdYok, "Aktifleştirilecek kullanıcı bulunamadı.");
            }
            return res;
        }
    }
}
