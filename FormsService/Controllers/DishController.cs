using Application.Features.Dishes.Commands.CreateDish;
using Application.Features.Dishes.Commands.DeleteDish;
using Application.Features.Dishes.Commands.UpdateDish;
using Application.Features.Dishes.Queries.GetDishes;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FormsService.API.Controllers;

public class DishController : Controller
{
    private readonly ICreateDishHandler _createDishHandler;
    private readonly IDeleteDishHandler _deleteDishHandler;
    private readonly IGetAllDishesHandler _getAllDishesHandler;
    private readonly IGetDishesByCategoriesHandler _getDishesByCategoriesHandler;
    private readonly IUpdateDishHandler _updateDishHandler;

    public DishController(ICreateDishHandler createDishHandler,
        IDeleteDishHandler deleteDishHandler,
        IGetAllDishesHandler getAllDishesHandler,
        IGetDishesByCategoriesHandler getDishesByCategoriesHandler,
        IUpdateDishHandler updateDishHandler)
    {
        _createDishHandler = createDishHandler;
        _deleteDishHandler = deleteDishHandler;
        _getAllDishesHandler = getAllDishesHandler;
        _getDishesByCategoriesHandler = getDishesByCategoriesHandler;
        _updateDishHandler = updateDishHandler;
    }

    [HttpGet]
    [Route("getAll")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    public async Task<IActionResult> GetAllFromDb()
    {
        return Ok(await _getAllDishesHandler.HandleGetAlldishes());
    }

    [HttpPost]
    [Route("createDish")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateDish([FromBody] Dish dish)
    {
        return Ok(await _createDishHandler.HandleCreateDish(dish));
    }

    [HttpPut]
    [Route("updateDish")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateDish([FromBody] Dish dish)
    {
        return Ok(await _updateDishHandler.HandleUpdateDish(dish));
    }

    [HttpDelete]
    [Route("deleteDish/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteDish(int id)
    {
        return Ok(await _deleteDishHandler.HandleDeleteDish(id));
    }

    [HttpGet("getDishesByCategories")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    public async Task<IActionResult> GetDishesByCategories()
    {
        return Ok(_getDishesByCategoriesHandler.HandleGetDishesByCategoriesAsync());
    }
}