using Application.Interfaces;

namespace Application.Features.Persons.Commands.CreatePerson;

public interface ICreatePersonHandler : IHandler
{
    Task<PersonDto?> HandleCreatePerson(PersonDto person);
}