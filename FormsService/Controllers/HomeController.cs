using FormsService.DAL.Repository.Interfaces;
using MailService.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormsService.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class HomeController : Controller
    {
        private readonly IRepository<MenuModel> _repository;

        public HomeController(IRepository<MenuModel> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            //var items = await _repository.GetAll();
            //return Ok(items);
        }
    }
}