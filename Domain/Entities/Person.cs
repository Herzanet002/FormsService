using Domain.Common;

namespace Domain.Entities;

public class Person : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<Order>? Orders { get; set; }
}