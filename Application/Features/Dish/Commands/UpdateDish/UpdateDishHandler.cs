using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Features.Dish.Commands.UpdateDish
{
    public class UpdateDishHandler : IUpdateDishHandler
    {
        private readonly IRepository<Domain.Entities.Dish> _repository;

        public UpdateDishHandler(IRepository<Domain.Entities.Dish> repository)
        {
            _repository = repository;
        }
        public async ValueTask<Domain.Entities.Dish> HandleUpdateDish(Domain.Entities.Dish dish)
        {
            return await _repository.Update(dish);
        }
    }
}
