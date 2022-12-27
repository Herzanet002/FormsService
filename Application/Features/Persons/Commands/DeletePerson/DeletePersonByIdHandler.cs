using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Features.Persons.Commands.DeletePerson
{
    public class DeletePersonByIdHandler : IDeletePersonByIdHandler
    {
        private readonly IPersonRepository _personRepository;

        public DeletePersonByIdHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<Person?> HandleDeletePersonById(int id)
        {
            return await _personRepository.RemoveById(id);
        }
    }
}
