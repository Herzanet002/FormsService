using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Features.Persons.Commands.DeletePerson
{
    public class DeletePersonHandler : IDeletePersonHandler
    {
        private readonly IPersonRepository _personRepository;

        public DeletePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<Person?> HandleDeletePerson(Person person)
        {
            return await _personRepository.Remove(person);
        }

    }
}
