using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Persons.Commands.UpdatePerson;

public interface IUpdatePersonHandler : IHandler
{
    Task<Person?> HandleUpdatePerson(Person person);
}