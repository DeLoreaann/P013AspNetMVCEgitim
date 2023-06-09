﻿using Microsoft.AspNetCore.Mvc;

namespace P013AspNetMVCEgitim.Controllers
{
	public class MVC08ViewResultsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Yonlendir(string arananDeger)
		{

			// return Redirect("/Home"); Bu action tetiklendiğinde uygulama anasayfaya gitsin.
			//return Redirect($"/Home?kelime={arananDeger}"); 
			// burada ? işaretinden sonraki kısım querystring yöntemiyle adres çubuğu üzerinden veri yollamak için var.
			return Redirect("https://getbootstrap.com/");

		}

		public IActionResult ActionaYonlendir()
		{
			// return RedirectToAction("Index");  metot çalıştığında aynı controllerdaki bir actiona yönlendirmemizi sağlar.
			return RedirectToAction("Index","Home"); // metot çalıştığında farklı bir contoller daki actiona bu şekilde yönlendirebiliriz.
		}

		public IActionResult RouteYonlendir()
		{
			return RedirectToRoute("Default", new { controller="Home", action="Index", id = 18}); // metot çalıştığında route sistemiyle yönlendirme yapmamızı sağlar.
		}
	}
}
