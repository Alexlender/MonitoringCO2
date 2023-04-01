using Generator.Implementations;
using Generator.Interfaces;
using Generator.Models;
using Microsoft.AspNetCore.Mvc;
using Monitoring.Services;
using System.Diagnostics;

namespace Generator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult SourceButton()
        {
            AreaSource.AddSource("adadadddada");
            return Redirect("/");
        }
        //filePath();

        public IActionResult Index()
        {
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