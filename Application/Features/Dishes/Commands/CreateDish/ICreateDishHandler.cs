using Application.Interfaces;

namespace Application.Features.Dishes.Commands.CreateDish;

public interface ICreateDishHandler : IHandler
{
    Task<DishDto> HandleCreateDish(DishDto dish);
}