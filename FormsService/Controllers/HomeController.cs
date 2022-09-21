using MailService.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace FormsService.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class HomeController : Controller
    {
        private readonly IServiceProvider _serviceProvider;
        public HomeController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            var t = _serviceProvider.GetRequiredService<IMapClientConfigurations>();
            return Ok();
        }
    }
}
