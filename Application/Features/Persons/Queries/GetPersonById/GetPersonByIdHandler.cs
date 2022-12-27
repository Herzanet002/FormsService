using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Features.Persons.Queries.GetPersonById
{
    public class GetPersonByIdHandler : IGetPersonByIdHandler
    {
        private readonly IPersonRepository _personRepository;

        public GetPersonByIdHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<Person?> HandleGetPersonById(int id)
        {
            return await _personRepository.FindById(id);
        }
    }
}
