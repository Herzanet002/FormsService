using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Persons.Queries.GetAllPersons;

public interface IGetAllPersonsHandler : IHandler
{
    Task<IEnumerable<Person>> HandleGetAllPersons();
}