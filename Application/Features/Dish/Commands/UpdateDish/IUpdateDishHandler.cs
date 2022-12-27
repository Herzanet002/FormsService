using Application.Interfaces;

namespace Application.Features.Dish.Commands.UpdateDish;

public interface IUpdateDishHandler : IHandler
{
    ValueTask<Domain.Entities.Dish> HandleUpdateDish(Domain.Entities.Dish dish);
}