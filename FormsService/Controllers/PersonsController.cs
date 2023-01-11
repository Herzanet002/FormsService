using Application.Features.Persons.Commands.CreatePerson;
using Application.Features.Persons.Commands.DeletePerson;
using Application.Features.Persons.Commands.UpdatePerson;
using Application.Features.Persons.Queries;
using Application.Features.Persons.Queries.GetAllPersons;
using Application.Features.Persons.Queries.GetPersonById;
using FormsService.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace FormsService.API.Controllers;
public class PersonsController : ApiControllerBase
{
    private readonly ICreatePersonHandler _createPersonHandler;
    private readonly IUpdatePersonHandler _updatePersonHandler;
    private readonly IDeletePersonHandler _deletePersonHandler;
    private readonly IGetAllPersonsHandler _getAllPersonsHandler;
    private readonly IGetPersonByIdHandler _getPersonByIdHandler;
    private readonly IDeletePersonByIdHandler _deletePersonByIdHandler;

    public PersonsController(ICreatePersonHandler createPersonHandler,
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _getAllPersonsHandler.HandleGetAllPersons());
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        return await _getPersonByIdHandler.HandleGetPersonById(id) is { } item ? Ok(item) : NotFound();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreatePerson([FromBody] CreatePersonCommand person)
    {
        return Ok(await _createPersonHandler.HandleCreatePerson(person));
    }

    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdatePerson(int id, [FromBody] GetPersonCommand personDto)
    {
        if (id != personDto.Id) return BadRequest();

        var updatedPerson = await _updatePersonHandler.HandleUpdatePerson(personDto);
        return Ok(updatedPerson);
    }

    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePersonById(int id)
    {
        var deletedPerson = await _deletePersonByIdHandler.HandleDeletePersonById(id);
        return Ok(deletedPerson);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePerson([FromBody] DeletePersonCommand person)
    {
        var deletedPerson = await _deletePersonHandler.HandleDeletePerson(person);
        return Ok(deletedPerson);
    }
}