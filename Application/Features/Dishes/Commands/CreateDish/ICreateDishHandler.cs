using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Dishes.Commands.CreateDish;

public interface ICreateDishHandler : IHandler
{
    Task<Dish> HandleCreateDish(Dish dish);
}