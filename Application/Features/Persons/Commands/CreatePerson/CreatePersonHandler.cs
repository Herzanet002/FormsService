using Domain.Entities;
using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Persons.Commands.CreatePerson;

public class CreatePersonHandler : ICreatePersonHandler
{
    private readonly IPersonRepository _personRepository;

    public CreatePersonHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<CreatePersonCommand?> HandleCreatePerson(CreatePersonCommand personDto)
    {
        var personModel = personDto.Adapt<Person>();
        var addedPerson = await _personRepository.Add(personModel);
        return addedPerson.Adapt<CreatePersonCommand>();
    }
}