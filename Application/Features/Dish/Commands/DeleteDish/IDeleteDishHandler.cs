using Application.Interfaces;

namespace Application.Features.Dish.Commands.DeleteDish;

public interface IDeleteDishHandler : IHandler
{
    ValueTask<Domain.Entities.Dish> HandleDeleteDish(int id);
}