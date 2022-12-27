using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Repository.Common;

namespace Infrastructure.Persistence.Repository
{
    public class DishCategoryRepository : DbRepository<DishCategory>, IDishCategoryRepository
    {
        public DishCategoryRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
