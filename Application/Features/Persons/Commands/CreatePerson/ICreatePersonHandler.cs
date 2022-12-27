using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Persons.Commands.CreatePerson;

public interface ICreatePersonHandler : IHandler
{
    Task<PersonDto?> HandleCreatePerson(PersonDto person);
}