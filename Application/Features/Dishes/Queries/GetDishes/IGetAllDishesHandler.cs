using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Dishes.Queries.GetDishes;

public interface IGetAllDishesHandler : IHandler
{
    Task<IEnumerable<Dish>> HandleGetAlldishes();
}