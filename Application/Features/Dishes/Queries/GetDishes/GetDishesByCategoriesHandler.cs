using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Dishes.Queries.GetDishes;

public class GetDishesByCategoriesHandler : IGetDishesByCategoriesHandler
{
    private readonly IDishRepository _dishRepository;


    public GetDishesByCategoriesHandler(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    public async Task<IEnumerable<GetDishWithCategoryCommand>> HandleGetDishesByCategoriesAsync()
    {
        var dishes = await _dishRepository.GetAllWithInclude(x => x.Category!);
        var groupedDishes = dishes.GroupBy(x => x.Category);
        var dishesByCategories = new List<GetDishWithCategoryCommand>();
        foreach (var group in groupedDishes)
            if (group.Key != null)
                dishesByCategories.Add(new GetDishWithCategoryCommand
                {
                    Id = group.Key.Id,
                    CategoryTitle = group.Key.Name,
                    Dishes = group.Select(dish => dish).ToList().Adapt<IEnumerable<GetDishCommand>>()
                });

        return dishesByCategories;
    }
}