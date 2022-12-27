using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Persons.Queries.GetPersonById;

public interface IGetPersonByIdHandler : IHandler
{
    Task<Person?> HandleGetPersonById(int id);
}