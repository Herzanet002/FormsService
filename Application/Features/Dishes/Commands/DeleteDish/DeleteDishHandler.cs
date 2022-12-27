using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Features.Dishes.Commands.DeleteDish;

public class DeleteDishHandler : IDeleteDishHandler
{
    private readonly IDishRepository _dishRepository;

    public DeleteDishHandler(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    public async Task<Dish?> HandleDeleteDish(int id)
    {
        return await _dishRepository.RemoveById(id);
    }
}