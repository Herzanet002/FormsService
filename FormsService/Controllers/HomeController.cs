using FormsService.DAL.Entities;
using FormsService.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FormsService.Controllers;

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

    #region HttpGet

    /// <summary>
    /// GetAlls
    /// </summary>
    /// <returns></returns>
    [HttpGet, Route("GetAllDishes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllDishesFromDb()
    {
        return Ok(await _dishRepository.GetAll());
    }

    [HttpGet, Route("GetAllPersons")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllPersonsFromDb()
    {
        return Ok(await _personsRepository.GetAll());
    }

    [HttpGet, Route("GetAllOrders")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllOrdersFromDb()
    {
        return Ok(await _ordersRepository.GetAll());
    }

    /// <summary>
    /// GetById
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet, Route("GetDishById/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDishById(int id) =>
        await _dishRepository.FindById(id) is { } item ? Ok(item) : NotFound();

    [HttpGet, Route("GetPersonById/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPersonById(int id) =>
        await _personsRepository.FindById(id) is { } item ? Ok(item) : NotFound();

    [HttpGet, Route("GetOrderById/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOrderById(int id) =>
        await _ordersRepository.FindById(id) is { } item ? Ok(item) : NotFound();

    #endregion

    #region HttpPost

    [HttpPost, Route("AddPerson")]
    public async Task<IActionResult> AddPersonToDb([FromBody] string personName)
    {
        var response = await _personsRepository.Add(new Person
        {
            Name = personName
        });

        return Ok(response);
    }

    #endregion


}