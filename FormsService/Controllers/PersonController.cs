using FormsService.API.Controllers.Base;
using FormsService.DAL.Entities;
using FormsService.DAL.Repository.Interfaces;

namespace FormsService.API.Controllers;

public class PersonController : EntityController<Person>
{
    public PersonController(IRepository<Person> repository) : base(repository)
    {
    }
}