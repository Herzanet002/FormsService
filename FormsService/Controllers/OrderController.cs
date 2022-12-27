using Application.Interfaces.Repositories;
using Domain.Entities;
using FormsService.API.Controllers.Base;

namespace FormsService.API.Controllers;

public class OrderController : EntityController<Order>
{
    public OrderController(IRepository<Order> repository) : base(repository)
    {
    }
}