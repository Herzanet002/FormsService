using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Features.Persons.Commands.UpdatePerson
{
    public class UpdatePersonHandler : IUpdatePersonHandler
    {
        private readonly IPersonRepository _personRepository;

        public UpdatePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<Person?> HandleUpdatePerson(Person person)
        {
            return await _personRepository.Update(person);
        }
    }
}
