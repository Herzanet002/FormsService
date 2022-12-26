﻿using Application.Features.Dish.Commands.CreateDish;
using Domain.Entities;
using FormsService.API.Controllers.Base;
using Infrastructure.Persistence.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FormsService.API.Controllers
{
    public class DishController : EntityController<Dish>
    {
        private readonly IRepository<Dish> _repository;
        private readonly ICreateDishHandler _createDishHandler;

        public DishController(IRepository<Dish> repository, ICreateDishHandler createDishHandler) : base(repository)
        {
            _repository = repository;
            _createDishHandler = createDishHandler;
        }

        [HttpGet, Route("getAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public override async Task<IActionResult> GetAllFromDb()
        {
            var allWithInclude = await _repository.GetAllWithInclude(x => x.Category!);
            return Ok(allWithInclude);
        }

        [HttpPost, Route("createDish")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateDish([FromBody] Dish dish)
        {
            return Ok(await _createDishHandler.HandleCreateDish(dish));
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