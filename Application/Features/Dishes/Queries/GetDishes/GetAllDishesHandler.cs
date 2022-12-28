using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Dishes.Queries.GetDishes;

public class GetAllDishesHandler : IGetAllDishesHandler
{
    private readonly IDishRepository _dishRepository;

    public GetAllDishesHandler(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    public async Task<IEnumerable<DishDto>> HandleGetAllDishes()
    {
        var dishes = await _dishRepository.GetAllWithInclude(x => x.Category!);
        return dishes.Adapt<IEnumerable<DishDto>>();
    }
}