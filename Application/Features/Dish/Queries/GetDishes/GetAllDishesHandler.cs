using Application.Interfaces.Repositories;

namespace Application.Features.Dish.Queries.GetDishes
{
    public class GetAllDishesHandler : IGetAllDishesHandler
    {
        private readonly IRepository<Domain.Entities.Dish> _repository;

        public GetAllDishesHandler(IRepository<Domain.Entities.Dish> repository)
        {
            _repository = repository;
        }
        public async ValueTask<IEnumerable<Domain.Entities.Dish>> HandleGetAlldishes()
        {
            return await _repository.GetAllWithInclude(x => x.Category!);
        }
    }
}
