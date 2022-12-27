using Application.Interfaces;

namespace Application.Features.Dish.Queries.GetDishes;

public interface IGetAllDishesHandler : IHandler
{
    ValueTask<IEnumerable<Domain.Entities.Dish>> HandleGetAlldishes();
}