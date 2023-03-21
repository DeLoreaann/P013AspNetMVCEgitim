using Microsoft.AspNetCore.Mvc;
using P013AspNetMVCEgitim.Models;

namespace P013AspNetMVCEgitim.Controllers
{
	public class MVC05ModelValidationController : Controller
	{
		UyeContext context = new UyeContext(); // program.cs tarafında builder.services olarak uyecontext ekledikten sonra burada controller tarafına ekliyoruz ki context i kullanabilelim.
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult UyeListesi()
		{
			var model = context.Uyes.ToList(); // context içinde yer alan Uyes tablosundaki verileri listele ve değişkene aktar.
			return View(model); /*View sayfasına model bu şekilde gönderiliyor.*/
		}
		public IActionResult YeniUye()
		{
			return View();
		}
		[HttpPost]
		public IActionResult YeniUye(Uye uye)
		{
			if (ModelState.IsValid)// eğer parantez içerisinde gönderilen uye nesnesi validasyon kurallarına uygunsa
			{
				// bu bloktaki kodları çalıştırır. Mesela gönderilen uye nesnesini veritabanına ekle
				context.Uyes.Add(uye); // view den gönderilen uye nesnesini context üzerindeki uyes tablosuna ekle
				context.SaveChanges(); // üst satırdaki ekleme işlemini kaydet.
				return RedirectToAction("UyeListesi");
			}
			else
			{
				ModelState.AddModelError("", "Lütfen Zorunlu Alanları Doldurunuz!");
			}
			return View();
		}

		public IActionResult UyeDuzenle(int id) // üye düzenlerken mevcut bilgilerin ekrana yansıması için id ile düzenlenecek olan üye bilgilerini ekrana yansıtırız.
		{
			var kayit = context.Uyes.Find(id); // Find kodu entity framework un bize verdiği default bir metot. adres çubuğundaki route üzerinden gönderilen id ile eşleşen kaydı bul.
			return View(kayit);
		}
		[HttpPost]
		public IActionResult UyeDuzenle(Uye uye)
		{
			if (ModelState.IsValid)
			{
				// bu bloktaki kodları çalıştırır. Mesela gönderilen uye nesnesini veritabanına ekle
				context.Uyes.Update(uye); // view den gönderilen uye nesnesini güncelle
				context.SaveChanges(); // üst satırdaki güncelleme işlemini kaydet.
				return RedirectToAction("UyeListesi");
			}
			else
			{
				ModelState.AddModelError("", "Lütfen Zorunlu Alanları Doldurunuz!");
			}
			return View();
		}

		public IActionResult UyeSil(int id) 
		{
			var kayit = context.Uyes.Find(id); // Find kodu entity framework un bize verdiği default bir metot. adres çubuğundaki route üzerinden gönderilen id ile eşleşen kaydı bul.
			return View(kayit);
		}
		[HttpPost]
		public IActionResult UyeSil(Uye uye)
		{
			try
			{
                context.Uyes.Remove(uye);
                context.SaveChanges();
                return RedirectToAction("UyeListesi");
            }
			catch (Exception hata)
			{
				ModelState.AddModelError("", "Hata oluştu!" + hata.Message);

            }
			return View(uye);
			
				
			
			
		}
	}
}
