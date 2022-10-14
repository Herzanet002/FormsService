using FormsService.DAL.Entities.Base;

namespace FormsService.DAL.Entities;

public class Person : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<Order>? Orders { get; set; }
}

public enum Location
{
    WithMe, // возьму с собой
    InCafe  // в кафе
}