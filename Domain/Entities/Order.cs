using System.Text.Json.Serialization;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Order : BaseEntity
{
    public Person Person { get; set; }
    public Location Location { get; set; }
    public DateTimeOffset DateForming { get; set; }

    public virtual ICollection<Dish> Dishes { get; set; }

    [JsonIgnore] public virtual ICollection<DishOrder>? DishOrders { get; set; }
}