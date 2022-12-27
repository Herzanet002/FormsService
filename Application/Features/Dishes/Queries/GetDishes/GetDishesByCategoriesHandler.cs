using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Base;

namespace Application.Features.Dishes.Queries.GetDishes;

public class GetDishesByCategoriesHandler : IGetDishesByCategoriesHandler
{
    private readonly IDishRepository _dishRepository;


    public GetDishesByCategoriesHandler(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    public async Task<IEnumerable<object>> HandleGetDishesByCategoriesAsync()
    {
        var dishes = await _dishRepository.GetAllWithInclude(x => x.Category);
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