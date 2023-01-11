using Domain.Common;

namespace Domain.Entities;

public class Order : BaseEntity
{
    public Person Person { get; set; }
    public int PersonId { get; set; }
    public Location Location { get; set; }
    public int LocationId { get; set; }
    public DateTimeOffset DateForming { get; set; }
    public virtual ICollection<Dish> Dishes { get; set; }
    public virtual ICollection<DishOrder>? DishOrders { get; set; }
}