using FormsService.API.Controllers.Base;
using FormsService.DAL.Entities;
using FormsService.DAL.Repository.Interfaces;

namespace FormsService.API.Controllers
{
    public class DishController : EntityController<Dish>
    {
        public DishController(IRepository<Dish> repository) : base(repository)
        {
        }
    }
}