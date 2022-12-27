using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Repository.Common;

namespace Infrastructure.Persistence.Repository
{
    public class OrderRepository : DbRepository<Order>, IOrderRepository
    {
        public OrderRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
