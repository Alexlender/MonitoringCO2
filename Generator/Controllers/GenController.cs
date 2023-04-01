using Generator.Implementations;
using Generator.Interfaces;
using Generator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Generator.Controllers
{
    public class GenController : Controller
    {
        private readonly ILogger<GenController> _logger;

        public GenController(ILogger<GenController> logger)
        {
            _logger = logger;
        }

        public IActionResult SourceButton()
        {
            AreaSource.AddSource("adadadddada");
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Help()
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