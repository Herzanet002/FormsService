using Microsoft.AspNetCore.Mvc;

namespace FormsService.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class HomeController : Controller
    {
        //private readonly IOptionsMonitor<ClientSettings> _optionsDelegate;
        public HomeController()
        {
            //_optionsDelegate = optionsDelegate;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ///var msc = new MailServiceClient(_optionsDelegate.CurrentValue);
            //var messages = await msc.ReceiveItem();
            //return Ok(messages);
            return Ok();
        }
    }
}