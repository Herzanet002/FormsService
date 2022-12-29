using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Dishes.Commands.DeleteDish;

public class DeleteDishHandler : IDeleteDishHandler
{
    private readonly IDishRepository _dishRepository;

    public DeleteDishHandler(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    public async Task<DeleteDishCommand?> HandleDeleteDish(int id)
    {
        var removed = await _dishRepository.RemoveById(id);
        return removed?.Adapt<DeleteDishCommand>();
    }
}