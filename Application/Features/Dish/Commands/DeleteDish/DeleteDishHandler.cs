using Application.Interfaces.Repositories;

namespace Application.Features.Dish.Commands.DeleteDish
{
    public class DeleteDishHandler : IDeleteDishHandler
    {
        private readonly IRepository<Domain.Entities.Dish> _repository;

        public DeleteDishHandler(IRepository<Domain.Entities.Dish> repository)
        {
            _repository = repository;
        }

        public async ValueTask<Domain.Entities.Dish> HandleDeleteDish(int id)
        {
           return await _repository.RemoveById(id);
        }
    }
}
