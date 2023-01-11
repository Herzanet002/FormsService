namespace Application.Features.Locations.Queries.GetAllLocations;

public record GetAllLocationsCommand
{
    public int Id { get; set; }
    public string Name { get; set; }
}