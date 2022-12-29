using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Categories.Queries.GetCategories
{
    public class GetAllCategoriesHandler : IGetAllCategoriesHandler
    {
        private readonly IDishCategoryRepository _categoryRepository;

        public GetAllCategoriesHandler(IDishCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<GetCategoryCommand>> HandleGetAllCategories()
        {
            var categories = await _categoryRepository.GetAll();
            return categories.Adapt<IEnumerable<GetCategoryCommand>>();
        }
    }
}
