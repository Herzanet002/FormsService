using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Dishes.Commands.DeleteDish;

public interface IDeleteDishHandler : IHandler
{
    Task<Dish?> HandleDeleteDish(int id);
}