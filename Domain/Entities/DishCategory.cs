using System.Text.Json.Serialization;
using Domain.Common;

namespace Domain.Entities;

public class DishCategory : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Dish>? Dishes { get; set; }
}