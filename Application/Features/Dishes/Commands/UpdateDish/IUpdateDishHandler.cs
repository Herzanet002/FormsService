using Application.Interfaces;

namespace Application.Features.Dishes.Commands.UpdateDish;

public interface IUpdateDishHandler : IHandler
{
    Task<DishDto> HandleUpdateDish(DishDto dish);
}