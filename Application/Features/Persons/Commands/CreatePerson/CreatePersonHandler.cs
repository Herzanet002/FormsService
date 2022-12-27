using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Features.Persons.Commands.CreatePerson
{
    public class CreatePersonHandler : ICreatePersonHandler
    {
        private readonly IPersonRepository _personRepository;

        public CreatePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> HandleCreatePerson(Person person)
        {
            return await _personRepository.Add(person);
        }
    }
}
