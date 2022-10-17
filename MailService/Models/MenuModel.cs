using FormsService.DAL.Entities;
using FormsService.DAL.Entities.Base;
using System.Text.Json.Serialization;

namespace MailService.Models;

[Serializable]
public class MenuModel : BaseEntity
{
    [JsonPropertyName("Сотрудник")]
    [JsonConverter(typeof(JsonPersonConverter<Person>))]
    public Person Person { get; set; }

    [JsonPropertyName("Где обедаю?")]
    public string Location { get; set; }

    [JsonPropertyName("Салат")]
    [JsonConverter(typeof(JsonDishConverter<Dish>))]
    public Dish? Salad { get; set; }

    [JsonConverter(typeof(JsonDishConverter<Dish>))]
    [JsonPropertyName("Суп")]
    public Dish? Soup { get; set; }

    [JsonPropertyName("Горячее")]
    [JsonConverter(typeof(JsonDishConverter<Dish>))]
    public Dish? FirstCourse { get; set; }
}