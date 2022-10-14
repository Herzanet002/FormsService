using FormsService.DAL.Entities.Base;

namespace FormsService.DAL.Entities
{
    public class Dish : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<DishOrder>? DishOrders { get; set; }
    }
}