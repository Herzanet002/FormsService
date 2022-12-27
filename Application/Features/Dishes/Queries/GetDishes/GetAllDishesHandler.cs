using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Base;

namespace Application.Features.Dishes.Queries.GetDishes;

public class GetAllDishesHandler : IGetAllDishesHandler
{
    private readonly IDishRepository _dishRepository;

    public GetAllDishesHandler(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    public async Task<IEnumerable<Dish>> HandleGetAlldishes()
    {
        return await _dishRepository.GetAllWithInclude(x => x.Category!);
    }
}