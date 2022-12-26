namespace Application.Features.Dish.Commands.CreateDish
{
    public interface ICreateDishHandler
    {
        Task<Domain.Entities.Dish> HandleCreateDish(Domain.Entities.Dish dish);
    }
}

