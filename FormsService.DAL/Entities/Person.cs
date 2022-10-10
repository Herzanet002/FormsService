using FormsService.DAL.Entities.Base;

namespace FormsService.DAL.Entities;

public class Person : BaseEntity
{
    public string Name { get; set; }
    public int OrderID { get; set; }
    public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
}

public enum Location
{
    WithMe, // возьму с собой
    InCafe  // в кафе
}