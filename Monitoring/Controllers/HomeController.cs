using Microsoft.AspNetCore.Mvc;
using Monitoring.Models;
using System.Diagnostics;
using Monitoring.Interfaces;
using System.Reflection.Metadata;
using System;
using System.Threading.Tasks;
using Monitoring.Services;
using System.IO;

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

        public IActionResult AddFile(IFormFile file)
        {
            Console.WriteLine(file.FileName);
            if (!file.FileName.Contains(".json"))
            {
                Console.WriteLine("ERROR: Incorrect file type");
                return Redirect("/");
            }
            MemoryStream stream = new MemoryStream(); //
            
            file.CopyTo(stream);
            stream.Seek(0, SeekOrigin.Begin);
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();
            Console.WriteLine(text);
            _resourceService.AddParametersFromFile(text);
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