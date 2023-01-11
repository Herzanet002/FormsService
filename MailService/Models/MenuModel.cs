using System.Text.Json.Serialization;
using Domain.Entities;

namespace MailService.Models;

[Serializable]
public class MenuModel
{
    [JsonPropertyName("Сотрудник")]
    [JsonConverter(typeof(JsonPersonConverter<Person>))]
    public Person Person { get; set; }

    [JsonPropertyName("Где обедаю?")]
    [JsonConverter(typeof(JsonLocationConverter))]
    public Location Location { get; set; }

    [JsonIgnore] public List<Dish> Dishes { get; set; } = new();

    [JsonPropertyName("Салат")]
    [JsonConverter(typeof(JsonDishConverter<Dish>))]
    public Dish? Salad
    {
        set
        {
            if (value != null)
                Dishes.Add(value);
        }
    }

    [JsonConverter(typeof(JsonDishConverter<Dish>))]
    [JsonPropertyName("Суп")]
    public Dish? Soup
    {
        set
        {
            if (value != null)
                Dishes.Add(value);
        }
    }

    [JsonPropertyName("Горячее")]
    [JsonConverter(typeof(JsonDishConverter<Dish>))]
    public Dish? FirstCourse
    {
        set
        {
            if (value != null)
                Dishes.Add(value);
        }
    }
}