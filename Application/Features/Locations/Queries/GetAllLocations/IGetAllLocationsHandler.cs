using Application.Interfaces;

namespace Application.Features.Locations.Queries.GetAllLocations;

public interface IGetAllLocationsHandler : IHandler
{
    Task<IEnumerable<GetAllLocationsCommand>> HandleGetAllLocations();
}