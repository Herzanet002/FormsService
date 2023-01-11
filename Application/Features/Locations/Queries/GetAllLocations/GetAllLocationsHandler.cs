using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Locations.Queries.GetAllLocations;

public class GetAllLocationsHandler : IGetAllLocationsHandler
{
    private readonly ILocationRepository _locationRepository;

    public GetAllLocationsHandler(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }
    public async Task<IEnumerable<GetAllLocationsCommand>> HandleGetAllLocations()
    {
        var locations = await _locationRepository.GetAll();
        return locations.Adapt<IEnumerable<GetAllLocationsCommand>>();
    }
}