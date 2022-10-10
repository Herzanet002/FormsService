using BaseEntity = FormsService.DAL.Entities.Base.BaseEntity;

namespace FormsService.DAL.Entities
{
    public class Order : BaseEntity
    {
        public Person Person { get; set; }
        public Location Location { get; set; }
        public IEnumerable<Dish> Dishes { get; set; } = new List<Dish>();
        public IEnumerable<DishOrder> DishOrders { get; set; } = new List<DishOrder>();
    }
}
