using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Repository.Common;

namespace Infrastructure.Persistence.Repository;

public class LocationRepository : DbRepository<Location>, ILocationRepository
{
    public LocationRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }
}