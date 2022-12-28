using Application.Interfaces;

namespace Application.Features.Persons.Queries.GetPersonById;

public interface IGetPersonByIdHandler : IHandler
{
    Task<PersonDto?> HandleGetPersonById(int id);
}