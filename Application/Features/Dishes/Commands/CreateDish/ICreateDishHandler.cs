using Application.Interfaces;

namespace Application.Features.Dishes.Commands.CreateDish;

public interface ICreateDishHandler : IHandler
{
    Task<CreateDishCommand> HandleCreateDish(CreateDishCommand dish);
}