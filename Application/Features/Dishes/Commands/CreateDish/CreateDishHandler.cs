using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Features.Dishes.Commands.CreateDish;

public class CreateDishHandler : ICreateDishHandler
{
    private readonly IRepository<Dish> _repository;

    public CreateDishHandler(IRepository<Dish> repository)
    {
        _repository = repository;
    }

    public async Task<Dish> HandleCreateDish(Dish dish)
    {
        return await _repository.Add(dish);
    }
}