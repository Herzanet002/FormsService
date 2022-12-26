using Application.Interfaces.Repositories;

namespace Application.Features.Dish.Commands.CreateDish
{
    public class CreateDishHandler : ICreateDishHandler
    {
        private readonly IRepository<Domain.Entities.Dish> _repository;

        public CreateDishHandler(IRepository<Domain.Entities.Dish> repository)
        {
            _repository = repository;
        }
        public async Task<Domain.Entities.Dish> HandleCreateDish(Domain.Entities.Dish dish)
        {
            return await _repository.Add(dish);
            
        }
    }
}
