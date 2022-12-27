using Domain.Entities;
using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Persons.Commands.DeletePerson
{
    public class DeletePersonHandler : IDeletePersonHandler
    {
        private readonly IPersonRepository _personRepository;

        public DeletePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<PersonDto?> HandleDeletePerson(PersonDto personDto)
        {
            var person = personDto.Adapt<Person>();
            var removed = await _personRepository.Remove(person);
            return removed?.Adapt<PersonDto>();
        }

    }
}
