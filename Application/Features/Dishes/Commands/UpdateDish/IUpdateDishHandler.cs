using Application.Interfaces;

namespace Application.Features.Dishes.Commands.UpdateDish;

public interface IUpdateDishHandler : IHandler
{
    Task<UpdateDishCommand> HandleUpdateDish(UpdateDishCommand dish);
}