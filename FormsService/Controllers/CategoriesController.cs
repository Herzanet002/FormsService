using Application.Features.Categories.Queries.GetCategories;
using FormsService.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace FormsService.API.Controllers;

public class CategoriesController : ApiControllerBase
{
    private readonly IGetAllCategoriesHandler _getAllCategoriesHandler;

    public CategoriesController(IGetAllCategoriesHandler getAllCategoriesHandler)
    {
        _getAllCategoriesHandler = getAllCategoriesHandler;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    public async Task<IActionResult> GetAllCategories()
    {
        var handleGetAllCategories = await _getAllCategoriesHandler.HandleGetAllCategories();
        return Ok(handleGetAllCategories);
    }
}