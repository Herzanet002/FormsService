using System.Text.Json.Serialization;
using Domain.Common;

namespace Domain.Entities;

public class Dish : BaseEntity
{
    public string? Name { get; set; }

    public int DishPrice { get; set; }
    
    public bool IsActive { get; set; }

    public int DishCategoryId { get; set; }

    public DishCategory? Category { get; set; }

    public virtual ICollection<Order>? Orders { get; set; }

    public virtual ICollection<DishOrder>? DishOrders { get; set; }
}