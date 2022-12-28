using Application.Interfaces;

namespace Application.Features.Persons.Commands.DeletePerson;

public interface IDeletePersonHandler : IHandler
{
    Task<PersonDto?> HandleDeletePerson(PersonDto personDto);
}