using Application.Interfaces.Repositories;
using Domain.Entities;
using FormsService.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace FormsService.API.Controllers;

public class PersonController : EntityController<Person>
{
    private readonly IRepository<Person> _repository;

    public PersonController(IRepository<Person> repository) : base(repository)
    {
        _repository = repository;
    }

    [HttpPost, Route("createPerson")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreatePerson([FromBody] Person person)
    {
        var addedPerson = await _repository.Add(person);
        return Ok(addedPerson);
    }

    [HttpPut, Route("updatePerson")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdatePerson([FromBody] Person person)
    {
        var updatedPerson = await _repository.Update(person);
        return Ok(updatedPerson);
    }

    [HttpDelete, Route("deletePerson/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeletePerson(int id)
    {
        var deletedPerson = await _repository.RemoveById(id);
        return Ok(deletedPerson);
    }
}