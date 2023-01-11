using Application.Features.Locations.Queries.GetAllLocations;
using FormsService.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace FormsService.API.Controllers;

public class LocationsController : ApiControllerBase
{
    private readonly IGetAllLocationsHandler _getAllLocationsHandler;

    public LocationsController(IGetAllLocationsHandler getAllLocationsHandler)
    {
        _getAllLocationsHandler = getAllLocationsHandler;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    public async Task<IActionResult> GetAllLocations()
    {
        var handler = await _getAllLocationsHandler.HandleGetAllLocations();
        return Ok(handler);
    }
}