﻿using Microsoft.AspNetCore.Mvc;

namespace NumeralSystemConverterWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View("Privado");
        }
    }
}