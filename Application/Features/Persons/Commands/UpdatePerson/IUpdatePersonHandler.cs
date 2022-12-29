using Application.Features.Persons.Queries;
using Application.Interfaces;

namespace Application.Features.Persons.Commands.UpdatePerson;

public interface IUpdatePersonHandler : IHandler
{
    Task<GetPersonCommand?> HandleUpdatePerson(GetPersonCommand personDto);
}