using FormsService.DAL.Entities;
using FormsService.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FormsService.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class HomeController : Controller
    {
        private readonly IRepository<Dish> _dishRepository;
        private readonly IRepository<Person> _personsRepository;
        private readonly IRepository<Order> _ordersRepository;
        public HomeController(IRepository<Dish> dishRepository, IRepository<Person> personsRepository, IRepository<Order> ordersRepository)
        {
            _dishRepository = dishRepository;
            _personsRepository = personsRepository;
            _ordersRepository = ordersRepository;
        }

        [HttpPost, Route("AddDish")]
        public async Task<IActionResult> AddDishToDb([FromBody] string dish, int price)
        {
            var response = await _dishRepository.Add(new Dish
            {
                Name = dish,
                Price = price
            });
            return Ok(response);
        }

        [HttpGet, Route("GetAllDishes")]
        public async Task<IActionResult> GetAllDishesFromRepos()
        {
            return Ok(await _dishRepository.GetAll());
        }

        [HttpGet, Route("GetAllPersons")]
        public async Task<IActionResult> GetAllPersonsFromRepos()
        {
            return Ok(await _personsRepository.GetAll());
        }

        [HttpGet, Route("GetAllOrders")]
        public async Task<IActionResult> GetAllOrdersFromRepos()
        {
            return Ok(await _ordersRepository.GetAll());
        }

        [HttpPost, Route("AddPerson")]
        public async Task<IActionResult> AddPersonToDb([FromBody] string name)
        {
            var response = await _personsRepository.Add(new Person
            {
                Name = name
            });

            return Ok(response);
        }

        [HttpPost, Route("AddOrder")]
        public async Task<IActionResult> AddOrderToDb([FromBody] Person person)
        {
            var response = await _ordersRepository.Add(new Order
            {
                Person = person
            });

            return Ok(response);
        }

    }
}