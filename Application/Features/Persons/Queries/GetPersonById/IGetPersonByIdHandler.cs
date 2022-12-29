using Application.Interfaces;

namespace Application.Features.Persons.Queries.GetPersonById;

public interface IGetPersonByIdHandler : IHandler
{
    Task<GetPersonCommand?> HandleGetPersonById(int id);
}