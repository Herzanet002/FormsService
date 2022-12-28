using Application.Interfaces;

namespace Application.Features.Dishes.Queries.GetDishes;

public interface IGetAllDishesHandler : IHandler
{
    Task<IEnumerable<DishDto>> HandleGetAllDishes();
}