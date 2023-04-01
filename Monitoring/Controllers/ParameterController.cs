using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monitoring.Interfaces;
using Monitoring.Models;

namespace Monitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task AddDiarea(Diarea diarea)
        {
            Console.WriteLine("New Diarea" +
                $"Area: {diarea.area.Name}" +
                $"Params Count: {diarea.parameters.Count}");
        }

        [HttpPost]
        [Route("/adddata")]
        public async Task AddData(Parameter param)
        {

            Console.WriteLine("New param" +
                $"type: {param.type.name}" +
                $"num: {param.num}" +
                $"date: {param.date}");

            if (ModelState.IsValid)
            {
                _resourceService.AddParameter(param);
            }

        }
    }
}
