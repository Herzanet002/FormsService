using Domain.Entities;
using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Dishes.Commands.UpdateDish;

public class UpdateDishHandler : IUpdateDishHandler
{
    private readonly IDishRepository _dishRepository;


    public UpdateDishHandler(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    public async Task<DishDto> HandleUpdateDish(DishDto dishDto)
    {
        var dish = dishDto.Adapt<Dish>();
        var updated = await _dishRepository.Update(dish);
        return updated.Adapt<DishDto>();
    }
}