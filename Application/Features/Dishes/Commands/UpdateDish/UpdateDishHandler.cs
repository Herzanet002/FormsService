using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Features.Dishes.Commands.UpdateDish;

public class UpdateDishHandler : IUpdateDishHandler
{
    private readonly IRepository<Dish> _repository;

    public UpdateDishHandler(IRepository<Dish> repository)
    {
        _repository = repository;
    }

    public async Task<Dish> HandleUpdateDish(Dish dish)
    {
        return await _repository.Update(dish);
    }
}