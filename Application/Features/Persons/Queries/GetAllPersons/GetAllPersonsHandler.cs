using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Persons.Queries.GetAllPersons;

public class GetAllPersonsHandler : IGetAllPersonsHandler
{
    private readonly IPersonRepository _personRepository;

    public GetAllPersonsHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<IEnumerable<GetPersonCommand>> HandleGetAllPersons()
    {
        var persons = await _personRepository.GetAll();
        return persons.Adapt<IEnumerable<GetPersonCommand>>();
    }
}