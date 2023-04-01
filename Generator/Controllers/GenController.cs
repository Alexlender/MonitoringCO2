using Generator.Implementations;
using Generator.Interfaces;
using Generator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Monitoring.Models;
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
        public string area;
        [HttpPost]
        public IActionResult DiAreaAdd(string areaStr)
        {
            area = areaStr;
            return Redirect("/");
        }
        public IActionResult SourceButton()
        {
            AreaSource.AddSource(area);
            return Redirect("/");
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
            return View(new Monitoring.Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}