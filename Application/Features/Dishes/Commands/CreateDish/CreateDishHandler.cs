using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Features.Dishes.Commands.CreateDish;

public class CreateDishHandler : ICreateDishHandler
{
    private readonly IDishRepository _dishRepository;


    public CreateDishHandler(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    public async Task<Dish> HandleCreateDish(Dish dish)
    {
        return await _dishRepository.Add(dish);
    }
}