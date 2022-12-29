using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Persons.Queries.GetPersonById;

public class GetPersonByIdHandler : IGetPersonByIdHandler
{
    private readonly IPersonRepository _personRepository;

    public GetPersonByIdHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<GetPersonCommand?> HandleGetPersonById(int id)
    {
        var person = await _personRepository.FindById(id);
        return person?.Adapt<GetPersonCommand>();
    }
}