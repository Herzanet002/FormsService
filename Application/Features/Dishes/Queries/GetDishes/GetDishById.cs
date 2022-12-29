using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Dishes.Queries.GetDishes
{
    public class GetDishByIdHandler : IGetDishByIdHandler
    {
        private readonly IDishRepository _dishRepository;

        public GetDishByIdHandler(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }
        public async Task<GetDishCommand?> HandleGetDishById(int id)
        {
            var dish = await _dishRepository.FindById(id);
            return dish?.Adapt<GetDishCommand>();
        }
    }
}
