using Application.Interfaces;

namespace Application.Features.Dishes.Queries.GetDishes;

public interface IGetDishesByCategoriesHandler : IHandler
{
    Task<IEnumerable<GetDishWithCategoryCommand>> HandleGetDishesByCategoriesAsync();
}