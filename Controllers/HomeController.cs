using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Secrets_Demo.Models;

namespace Secrets_Demo.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration config;

        public HomeController(IConfiguration config)
        {
            this.config = config;
        }
        public IActionResult Index()
        {
            ViewBag.SecretKey1 = config["SecretKey1"];
            ViewBag.SecretKey2 = config["SecretKey2"];
            ViewBag.SecretKey3 =
        config["AppSettings:GlobalSettings:SecretKey3"];
            ViewBag.SecretKey4 =
        config["AppSettings:GlobalSettings:SecretKey4"];

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
