using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Persons.Commands.CreatePerson;

public interface ICreatePersonHandler : IHandler
{
    Task<Person> HandleCreatePerson(Person person);
}