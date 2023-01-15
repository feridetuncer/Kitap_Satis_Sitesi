using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KitapSatis.Entities.ValueObject
{
    public class UyelikViewModel
    {
        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(25, ErrorMessage ="{0}" +
            "maksimum {1} karakter olmalıdır.")]
        public string KullaniciAdi { get; set; }
        [DisplayName("E Posta"), Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(70, ErrorMessage = "{0}" +
            "maksimum {1} karakter olmalıdır."), EmailAddress(ErrorMessage ="{0} alanı için geçerli bir eposta adresi giriniz")]
        public string EMail { get; set; }
        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(25, ErrorMessage = "{0}" +
            "maksimum {1} karakter olmalıdır.")]
        public string Sifre { get; set; }
        [DisplayName("Şifre Tekrar"), Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(25, ErrorMessage = "{0}" +
            "maksimum {1} karakter olmalıdır."), Compare("Sifre", ErrorMessage ="{0} ile {1} aynı değil.")]
        public string ReSifre { get; set; }
    }
}