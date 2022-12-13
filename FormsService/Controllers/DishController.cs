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

        public override async Task<IActionResult> GetAllFromDb()
        {
            var allWithInclude = await _repository.GetAllWithInclude(x => x.Category);
            return Ok(allWithInclude);
        }

        [HttpPost, Route("createDish")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateDish([FromBody] Dish dish)
        {
            var addedDish = await _repository.Add(dish);
            return Ok(addedDish);
        }

        [HttpPut, Route("updateDish")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateDish([FromBody] Dish dish)
        {
            var updatedDish = await _repository.Update(dish);
            return Ok(updatedDish);
        }

        [HttpDelete, Route("deleteDish/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteDish(int id)
        {
            var deletedDish = await _repository.RemoveById(id);
            return Ok(deletedDish);
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