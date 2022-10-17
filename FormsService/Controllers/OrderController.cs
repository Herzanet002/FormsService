using FormsService.API.Controllers.Base;
using FormsService.DAL.Entities;
using FormsService.DAL.Repository.Interfaces;

namespace FormsService.API.Controllers
{
    public class OrderController : EntityController<Order>
    {
        public OrderController(IRepository<Order> repository) : base(repository)
        {
        }
    }
}