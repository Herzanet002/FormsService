using Application.Features.Dishes.Commands.CreateDish;
using Application.Features.Dishes.Commands.DeleteDish;
using Application.Features.Dishes.Commands.UpdateDish;
using Application.Features.Dishes.Queries.GetDishes;
using Microsoft.AspNetCore.Mvc;

namespace FormsService.API.Controllers;

[ApiController]
[Route("/api/[controller]/")]
public class DishesController : Controller
{
    private readonly ICreateDishHandler _createDishHandler;
    private readonly IDeleteDishHandler _deleteDishHandler;
    private readonly IGetAllDishesHandler _getAllDishesHandler;
    private readonly IGetDishesByCategoriesHandler _getDishesByCategoriesHandler;
    private readonly IUpdateDishHandler _updateDishHandler;
    private readonly IGetDishByIdHandler _getDishByIdHandler;

    public DishesController(ICreateDishHandler createDishHandler,
        IDeleteDishHandler deleteDishHandler,
        IGetAllDishesHandler getAllDishesHandler,
        IGetDishesByCategoriesHandler getDishesByCategoriesHandler,
        IUpdateDishHandler updateDishHandler,
        IGetDishByIdHandler getDishByIdHandler)
    {
        _createDishHandler = createDishHandler;
        _deleteDishHandler = deleteDishHandler;
        _getAllDishesHandler = getAllDishesHandler;
        _getDishesByCategoriesHandler = getDishesByCategoriesHandler;
        _updateDishHandler = updateDishHandler;
        _getDishByIdHandler = getDishByIdHandler;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    public async Task<IActionResult> GetAllDishes()
    {
        return Ok(await _getAllDishesHandler.HandleGetAllDishes());
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDishById(int id)
    {
        var dish = await _getDishByIdHandler.HandleGetDishById(id);
        return dish is null ? NotFound() : Ok(dish);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateDish([FromBody] CreateDishCommand dish)
    {
        return Ok(await _createDishHandler.HandleCreateDish(dish));
    }

    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateDish(int id, [FromBody] UpdateDishCommand dishDto)
    {
        if (dishDto.Id != id) return BadRequest();
        return Ok(await _updateDishHandler.HandleUpdateDish(dishDto));
    }

    //TODO: DeleteDish by dto

    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteDish(int id)
    {
        var deleted = await _deleteDishHandler.HandleDeleteDish(id);
        return deleted is null ? NotFound() : Ok(deleted);
    }

    [HttpGet("getByCategories")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    public async Task<IActionResult> GetDishesByCategories()
    {
        return Ok(await _getDishesByCategoriesHandler.HandleGetDishesByCategoriesAsync());
    }
}