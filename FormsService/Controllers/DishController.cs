using FormsService.API.Controllers.Base;
using FormsService.DAL.Entities;
using FormsService.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FormsService.API.Controllers
{
    public class DishController : EntityController<Dish>
    {
        private readonly IRepository<Dish> _repository;

        public DishController(IRepository<Dish> repository) : base(repository)
        {
            _repository = repository;
        }

        [HttpGet("getDishesByCategories")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> GetDishesByCategories()
        {
            var dishes = await _repository.GetAllWithInclude(x => x.Category);
            var groupedDishes = dishes.GroupBy(x => x.Category);
            var dishesByCategories = new List<object>();
            foreach (var group in groupedDishes)
            {
                dishesByCategories.Add(new
                {
                    Id = group.Key.Id,
                    Title = group.Key.Name,
                    Dishes = group.Select(dish => dish)
                });
            }
            return Ok(dishesByCategories);
        }
    }
}