using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Repository.Common;

namespace Infrastructure.Persistence.Repository
{
    public class DishOrderRepository : DbRepository<DishOrder>, IDishOrderRepository
    {
        public DishOrderRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
