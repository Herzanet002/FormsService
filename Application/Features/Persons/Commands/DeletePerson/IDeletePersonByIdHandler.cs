using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Persons.Commands.DeletePerson;

public interface IDeletePersonByIdHandler : IHandler
{
    Task<Person?> HandleDeletePersonById(int id);
}