using Application.Interfaces;

namespace Application.Features.Persons.Commands.DeletePerson;

public interface IDeletePersonByIdHandler : IHandler
{
    Task<DeletePersonCommand?> HandleDeletePersonById(int id);
}