using System.Text.Json.Serialization;
using FormsService.DAL.Entities.Base;

namespace FormsService.DAL.Entities;

public class Person : BaseEntity
{
    public string Name { get; set; }
    public string? Surname { get; set; }
    public virtual ICollection<Order>? Orders { get; set; }
}

public enum Location
{
    [JsonPropertyName("Возьму с собой")]
    WithMe, // возьму с собой
    [JsonPropertyName("В кафе")]
    InCafe  // в кафе
}