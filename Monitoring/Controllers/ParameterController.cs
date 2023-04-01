using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monitoring.Interfaces;
using Monitoring.Models;
using System.Net;

namespace Monitoring.Controllers
{
    //[ApiController]
    public class ParameterController : ControllerBase
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IResourceService _resourceService;
        public ParameterController(ILogger<HomeController> logger, IResourceService resourceService)
        {
            _logger = logger;
            _resourceService = resourceService;
        }

        [HttpPost]
        [Route("/adddiarea")]
        public async Task AddDiarea([FromBody] Diarea diarea)
        {
            Console.WriteLine("New Diarea" +
                $"Area: {diarea.area.name}" +
                $"Params Count: {diarea.parameters.Count}");
            _resourceService.AddDiarea(diarea);
        }


    }
}
