using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Repository.Common;

namespace Infrastructure.Persistence.Repository
{
    public class DishRepository : DbRepository<Dish>, IDishRepository
    {
        public DishRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
