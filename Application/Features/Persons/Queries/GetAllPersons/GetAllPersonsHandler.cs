using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Features.Persons.Queries.GetAllPersons
{
    public class GetAllPersonsHandler : IGetAllPersonsHandler
    {
        private readonly IPersonRepository _personRepository;

        public GetAllPersonsHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<IEnumerable<Person>> HandleGetAllPersons()
        {
            return await _personRepository.GetAllWithInclude(x => x.Orders!);
        }
    }
}
