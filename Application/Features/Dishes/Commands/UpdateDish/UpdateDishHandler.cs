using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Base;

namespace Application.Features.Dishes.Commands.UpdateDish;

public class UpdateDishHandler : IUpdateDishHandler
{
    private readonly IDishRepository _dishRepository;


    public UpdateDishHandler(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    public async Task<Dish> HandleUpdateDish(Dish dish)
    {
        return await _dishRepository.Update(dish);
    }
}