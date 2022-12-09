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
        public async Task GetDishesByCategories()
        {
            var c = await _repository.GetAllWithInclude(x => x.Category);
        }
    }
}