using Domain.Entities;
using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Dishes.Commands.CreateDish;

public class CreateDishHandler : ICreateDishHandler
{
    private readonly IDishRepository _dishRepository;

    public CreateDishHandler(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    public async Task<DishDto> HandleCreateDish(DishDto dishDto)
    {
        var dish = dishDto.Adapt<Dish>();
        var added = await _dishRepository.Add(dish);
        return added.Adapt<DishDto>();
    }
}