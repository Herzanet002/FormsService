using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Features.Dishes.Queries.GetDishes;

public class GetDishesByCategoriesHandler : IGetDishesByCategoriesHandler
{
    private readonly IRepository<Dish> _repository;

    public GetDishesByCategoriesHandler(IRepository<Dish> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<object>> HandleGetDishesByCategoriesAsync()
    {
        var dishes = await _repository.GetAllWithInclude(x => x.Category);
        var groupedDishes = dishes.GroupBy(x => x.Category);
        var dishesByCategories = new List<object>();
        foreach (var group in groupedDishes)
            dishesByCategories.Add(new
            {
                group.Key.Id,
                Title = group.Key.Name,
                Dishes = group.Select(dish => dish)
            });

        return dishesByCategories;
    }
}