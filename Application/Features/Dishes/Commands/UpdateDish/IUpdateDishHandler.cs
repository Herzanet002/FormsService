using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Dishes.Commands.UpdateDish;

public interface IUpdateDishHandler : IHandler
{
    Task<Dish> HandleUpdateDish(Dish dish);
}