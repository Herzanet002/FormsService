using Application.Interfaces.Repositories;

namespace Application.Features.Dish.Queries.GetDishes
{
    public class GetDishesByCategoriesHandler : IGetDishesByCategoriesHandler
    {
        private readonly IRepository<Domain.Entities.Dish> _repository;

        public GetDishesByCategoriesHandler(IRepository<Domain.Entities.Dish> repository)
        {
            _repository = repository;
        }
        public async ValueTask<IEnumerable<object>> HandleGetDishesByCategoriesAsync()
        {
            var dishes = await _repository.GetAllWithInclude(x => x.Category);
            var groupedDishes = dishes.GroupBy(x => x.Category);
            var dishesByCategories = new List<object>();
            foreach (var group in groupedDishes)
            {
                dishesByCategories.Add(new
                {
                    Id = group.Key.Id,
                    Title = group.Key.Name,
                    Dishes = group.Select(dish => dish)
                });
            }

            return dishesByCategories;
        }
    }
}
