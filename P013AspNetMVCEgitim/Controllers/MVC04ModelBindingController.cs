using Microsoft.AspNetCore.Mvc;
using P013AspNetMVCEgitim.Models;

namespace P013AspNetMVCEgitim.Controllers
{
	public class MVC04ModelBindingController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		//[Route("KullaniciDetay")]
		public IActionResult KullaniciDetay()
		{
			Kullanici kullanici = new Kullanici();
			kullanici.KullaniciAdi = "Admin";
			kullanici.Ad = "Murat";
			kullanici.Soyad = "Yılmaz";
			kullanici.Sifre = "123";
			kullanici.Email = "Murat@yilmaz.co";
			return View(kullanici); // View içerisinde model datası olarak kullanici nesnesini sayfaya gönderdik.
		}
		[HttpPost]
		public IActionResult KullaniciDetay(Kullanici kullanici) // post metodunda modelden gelen nesneyi bu şekilde parantez içinde yakalayabiliyoruz. Bu işleme MODEL BINDING denir.
		{
			return View(kullanici); // gelen kullanici nesnesini tekrardan ekrana yolla
		}

		public IActionResult AdresDetay()
		{
			Adres adres = new()
			{
				Sehir = "Trabzon", Ilce ="Merkez", AcikAdres="Gürbulak sk. No:35"
			};
			return View(adres);
		}

		public IActionResult UyeSayfasi()
		{
            Kullanici kullanici = new Kullanici();
            kullanici.KullaniciAdi = "Admin";
            kullanici.Ad = "Murat";
            kullanici.Soyad = "Yılmaz";
            kullanici.Sifre = "123";
            kullanici.Email = "Murat@yilmaz.co";

            Adres adres = new()
            {
                Sehir = "Trabzon",
                Ilce = "Merkez",
                AcikAdres = "Gürbulak sk. No:35"
            };
			var model = new UyeSayfasiViewModel()
			{
				Kullanici = kullanici,
				Adres = adres
			};
			return View(model);
		}
	}
}
