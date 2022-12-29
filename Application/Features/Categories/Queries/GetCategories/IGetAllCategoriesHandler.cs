using Application.Interfaces;

namespace Application.Features.Categories.Queries.GetCategories;

public interface IGetAllCategoriesHandler : IHandler
{
    Task<IEnumerable<GetCategoryCommand>> HandleGetAllCategories();
}