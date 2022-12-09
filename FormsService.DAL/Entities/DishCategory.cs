using System.ComponentModel.DataAnnotations.Schema;
using FormsService.DAL.Entities.Base;

namespace FormsService.DAL.Entities
{
    public class DishCategory: BaseEntity
    {
        public string Name { get; set; }
        public Dish Dish { get; set; }
    }
}
