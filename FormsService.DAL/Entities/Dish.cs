using FormsService.DAL.Entities.Base;

namespace FormsService.DAL.Entities
{
    public class Dish : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
        public IEnumerable<DishOrder> DishOrders { get; set; } = new List<DishOrder>();
    }
}