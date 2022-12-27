using Application.Interfaces;

namespace Application.Features.Dish.Commands.CreateDish
{
    public interface ICreateDishHandler : IHandler
    {
        ValueTask<Domain.Entities.Dish> HandleCreateDish(Domain.Entities.Dish dish);
    }
}

