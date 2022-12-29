using Application.Interfaces;

namespace Application.Features.Persons.Commands.CreatePerson;

public interface ICreatePersonHandler : IHandler
{
    Task<CreatePersonCommand?> HandleCreatePerson(CreatePersonCommand person);
}