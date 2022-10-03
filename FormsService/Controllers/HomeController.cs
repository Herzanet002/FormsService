using Microsoft.AspNetCore.Mvc;

namespace FormsService.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class HomeController : Controller
    {


        public HomeController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            //var items = await _repository.GetAll();
            return Ok();
        }
    }
}