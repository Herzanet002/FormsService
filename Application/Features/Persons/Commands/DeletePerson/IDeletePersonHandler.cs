using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Persons.Commands.DeletePerson
{
    public interface IDeletePersonHandler : IHandler
    {
        Task<Person?> HandleDeletePerson(Person person);
    }
}
