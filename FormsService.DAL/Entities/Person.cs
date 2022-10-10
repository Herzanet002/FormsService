using FormsService.DAL.Entities.Base;

namespace FormsService.DAL.Entities;

public class Person : BaseEntity
{
    public string Name { get; set; }
    public IEnumerable<Order> Orders { get; set; } = new List<Order>();
}

public enum Location
{
    WithMe, // возьму с собой
    InCafe  // в кафе
}