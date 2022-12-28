using Application.Interfaces;

namespace Application.Features.Persons.Queries.GetAllPersons;

public interface IGetAllPersonsHandler : IHandler
{
    Task<IEnumerable<PersonDto>> HandleGetAllPersons();
}