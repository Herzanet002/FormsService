using Application.Features.Persons;
using Application.Features.Persons.Commands.CreatePerson;
using Application.Features.Persons.Commands.DeletePerson;
using Application.Features.Persons.Commands.UpdatePerson;
using Application.Features.Persons.Queries.GetAllPersons;
using Application.Features.Persons.Queries.GetPersonById;
using Microsoft.AspNetCore.Mvc;

namespace FormsService.API.Controllers;
[ApiController]
[Route("/api/[controller]/")]
public class PersonController : Controller
{
    private readonly ICreatePersonHandler _createPersonHandler;
    private readonly IUpdatePersonHandler _updatePersonHandler;
    private readonly IDeletePersonHandler _deletePersonHandler;
    private readonly IGetAllPersonsHandler _getAllPersonsHandler;
    private readonly IGetPersonByIdHandler _getPersonByIdHandler;
    private readonly IDeletePersonByIdHandler _deletePersonByIdHandler;

    public PersonController(ICreatePersonHandler createPersonHandler,
        IUpdatePersonHandler updatePersonHandler,
        IDeletePersonHandler deletePersonHandler,
        IGetAllPersonsHandler getAllPersonsHandler,
        IGetPersonByIdHandler getPersonByIdHandler,
        IDeletePersonByIdHandler deletePersonByIdHandler)
    {
        _createPersonHandler = createPersonHandler;
        _updatePersonHandler = updatePersonHandler;
        _deletePersonHandler = deletePersonHandler;
        _getAllPersonsHandler = getAllPersonsHandler;
        _getPersonByIdHandler = getPersonByIdHandler;
        _deletePersonByIdHandler = deletePersonByIdHandler;
    }

    [HttpGet]
    [Route("getAll")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _getAllPersonsHandler.HandleGetAllPersons());
    }

    [HttpGet]
    [Route("getById/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        return await _getPersonByIdHandler.HandleGetPersonById(id) is { } item ? Ok(item) : NotFound();
    }

    [HttpPost]
    [Route("create")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreatePerson([FromBody] PersonDto person)
    {
        return Ok(await _createPersonHandler.HandleCreatePerson(person));
    }

    [HttpPut]
    [Route("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdatePerson([FromBody] PersonDto person)
    {
        var updatedPerson = await _updatePersonHandler.HandleUpdatePerson(person);
        return Ok(updatedPerson);
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeletePersonById(int id)
    {
        var deletedPerson = await _deletePersonByIdHandler.HandleDeletePersonById(id);
        return Ok(deletedPerson);
    }

    [HttpDelete]
    [Route("delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeletePerson([FromBody] PersonDto person)
    {
        var deletedPerson = await _deletePersonHandler.HandleDeletePerson(person);
        return Ok(deletedPerson);
    }
}