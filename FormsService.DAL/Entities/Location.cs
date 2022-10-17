using System.Text.Json.Serialization;

namespace FormsService.DAL.Entities;

public enum Location
{
    [JsonPropertyName("Возьму с собой")]
    WithMe, // возьму с собой

    [JsonPropertyName("В кафе")]
    InCafe  // в кафе
}