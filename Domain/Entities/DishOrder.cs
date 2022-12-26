using Domain.Common;

namespace Domain.Entities
{
    public class DishOrder : BaseEntity
    {
        public int OrderID { get; set; }
        public int DishID { get; set; }
        public Order Order { get; set; }
        public Dish Dish { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}