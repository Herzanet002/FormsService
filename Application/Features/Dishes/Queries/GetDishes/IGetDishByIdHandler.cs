using Application.Interfaces;

namespace Application.Features.Dishes.Queries.GetDishes;

public interface IGetDishByIdHandler : IHandler
{
    Task<GetDishCommand?> HandleGetDishById(int id);
}