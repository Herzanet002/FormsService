using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Features.Dishes.Queries.GetDishes;

public class GetAllDishesHandler : IGetAllDishesHandler
{
    private readonly IRepository<Dish> _repository;

    public GetAllDishesHandler(IRepository<Dish> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Dish>> HandleGetAlldishes()
    {
        return await _repository.GetAllWithInclude(x => x.Category!);
    }
}