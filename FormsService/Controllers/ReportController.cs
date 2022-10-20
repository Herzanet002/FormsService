using FormsService.DAL.Entities;
using FormsService.DAL.Repository;
using FormsService.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FormsService.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class MainController : Controller
    {
        private readonly IRepository<DishOrder> _dishOrderRepository;
        private readonly IRepository<Dish> _dishRepository;
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Order> _orderRepository;

        public MainController(IRepository<DishOrder> dishOrderRepository,
            IRepository<Dish> dishRepository,
            IRepository<Person> personRepository,
            IRepository<Order> orderRepository)
        {
            _dishOrderRepository = dishOrderRepository;
            _dishRepository = dishRepository;
            _personRepository = personRepository;
            _orderRepository = orderRepository;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> GetFile(string fileName)
        {
            var filePath = $"C:\\Users\\stoya\\source\\repos\\FormsService\\FormsService\\logs\\{fileName}"; // get file full path based on file name
            if (!System.IO.File.Exists(filePath))
            {
                return BadRequest();
            }
            return File(await System.IO.File.ReadAllBytesAsync(filePath), "application/octet-stream", fileName);
        }

    }
}
