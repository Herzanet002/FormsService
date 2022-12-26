using Domain.Entities;
using FormsService.API.Controllers.Base;
using Infrastructure.Persistence.Repository.Interfaces;

namespace FormsService.API.Controllers
{
    public class OrderController : EntityController<Order>
    {
        public OrderController(IRepository<Order> repository) : base(repository)
        {
        }
    }
}