using Domain.Entities;
using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Persons.Commands.DeletePerson
{
    public class DeletePersonByIdHandler : IDeletePersonByIdHandler
    {
        private readonly IPersonRepository _personRepository;

        public DeletePersonByIdHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<PersonDto?> HandleDeletePersonById(int id)
        {
            var removed = await _personRepository.RemoveById(id);
            return removed?.Adapt<PersonDto>() ;
        }
    }
}
