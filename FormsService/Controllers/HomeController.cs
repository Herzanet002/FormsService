using MailService;
using MailService.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FormsService.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class HomeController : Controller
    {
        private readonly IOptionsMonitor<ClientSettings> _optionsDelegate;
        public HomeController(IOptionsMonitor<ClientSettings> optionsDelegate)
        {
            _optionsDelegate = optionsDelegate;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var msc = new MailServiceClient(_optionsDelegate.CurrentValue);
            var messages = await msc.ReceiveEmail();
            return Ok(messages);
        }
    }
}
