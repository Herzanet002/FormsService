using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Features.Dishes.Commands.DeleteDish;

public class DeleteDishHandler : IDeleteDishHandler
{
    private readonly IRepository<Dish> _repository;

    public DeleteDishHandler(IRepository<Dish> repository)
    {
        _repository = repository;
    }

    public async Task<Dish> HandleDeleteDish(int id)
    {
        return await _repository.RemoveById(id);
    }
}