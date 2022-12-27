using System.Text.Json.Serialization;
using Domain.Entities;
using Domain.Enums;

namespace MailService.Models;

[Serializable]
public class MenuModel
{
    [JsonPropertyName("Сотрудник")]
    [JsonConverter(typeof(JsonPersonConverter<Person>))]
    public Person Person { get; set; }

    [JsonPropertyName("Где обедаю?")]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public Location Location { get; set; }

    [JsonIgnore] public List<DishWithPrice> Dishes { get; set; } = new();

    [JsonPropertyName("Салат")]
    [JsonConverter(typeof(JsonDishConverter<DishWithPrice>))]
    public DishWithPrice? Salad
    {
        set
        {
            if (value != null)
                Dishes.Add(value);
        }
    }

    [JsonConverter(typeof(JsonDishConverter<DishWithPrice>))]
    [JsonPropertyName("Суп")]
    public DishWithPrice? Soup
    {
        set
        {
            if (value != null)
                Dishes.Add(value);
        }
    }

    [JsonPropertyName("Горячее")]
    [JsonConverter(typeof(JsonDishConverter<DishWithPrice>))]
    public DishWithPrice? FirstCourse
    {
        set
        {
            if (value != null)
                Dishes.Add(value);
        }
    }
}