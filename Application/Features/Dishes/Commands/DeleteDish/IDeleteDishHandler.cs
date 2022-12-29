using Application.Interfaces;

namespace Application.Features.Dishes.Commands.DeleteDish;

public interface IDeleteDishHandler : IHandler
{
    Task<DeleteDishCommand?> HandleDeleteDish(int id);
}