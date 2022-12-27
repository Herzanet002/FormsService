using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Repository.Common;

namespace Infrastructure.Persistence.Repository
{
    public class PersonRepository : DbRepository<Person>, IPersonRepository
    {
        public PersonRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
