using Microsoft.AspNetCore.Mvc;
using Monitoring.Models;
using System.Diagnostics;
using Monitoring.Interfaces;
using System.Reflection.Metadata;
using System;
using System.Threading.Tasks;
using Monitoring.Services;

namespace Monitoring.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IResourceService _resourceService;
        public HomeController(ILogger<HomeController> logger, IResourceService resourceService)
        {
            _logger = logger;
            _resourceService = resourceService;
        }

        public IActionResult BackupButton()
        {
            Console.WriteLine("Button test");
            SqlBackup.backup_db();
            return Redirect("/");
        }

        public IActionResult Index()
        {
            return View(_resourceService.GetAllParameters());
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