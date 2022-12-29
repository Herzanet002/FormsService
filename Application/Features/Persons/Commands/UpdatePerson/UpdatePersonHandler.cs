using Application.Features.Persons.Queries;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Persons.Commands.UpdatePerson;

public class UpdatePersonHandler : IUpdatePersonHandler
{
    private readonly IPersonRepository _personRepository;

    public UpdatePersonHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<GetPersonCommand?> HandleUpdatePerson(GetPersonCommand personDto)
    {
        var person = personDto.Adapt<Person>();
        var updated = await _personRepository.Update(person);
        return updated.Adapt<GetPersonCommand>();
    }
}