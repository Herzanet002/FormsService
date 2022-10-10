using FormsService.DAL.Entities.Base;

namespace FormsService.DAL.Entities
{
    public class Dish : BaseEntity
    {
        public string Name { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
        public virtual IEnumerable<DishOrder> DishOrders { get; set; } = new List<DishOrder>();
    }
}