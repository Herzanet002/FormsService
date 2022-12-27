using Application.Interfaces;

namespace Application.Features.Dish.Queries.GetDishes;

public interface IGetDishesByCategoriesHandler : IHandler
{
    ValueTask<IEnumerable<object>> HandleGetDishesByCategoriesAsync();
}