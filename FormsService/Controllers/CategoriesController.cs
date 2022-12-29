using Application.Features.Categories.Queries.GetCategories;
using Microsoft.AspNetCore.Mvc;

namespace FormsService.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class CategoriesController : Controller
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
}
