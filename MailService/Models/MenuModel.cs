using FormsService.DAL.Entities;
using System.Text.Json.Serialization;

namespace MailService.Models;

[Serializable]
public class MenuModel
{
    private DishWithPrice? _salad;
    private DishWithPrice? _soup;
    private DishWithPrice? _firstCourse;


    [JsonPropertyName("Сотрудник")]
    [JsonConverter(typeof(JsonPersonConverter<Person>))]
    public Person Person { get; set; }

    [JsonPropertyName("Где обедаю?")]
    public string Location { get; set; }

    public List<DishWithPrice> Dishes { get; set; } = new();


    [JsonPropertyName("Салат")]
    [JsonConverter(typeof(JsonDishConverter<DishWithPrice>))]
    public DishWithPrice? Salad
    {
        get => _salad;
        set
        {
            if (value != null)
                Dishes.Add(value);
            _salad = value;
        }
    }

    [JsonConverter(typeof(JsonDishConverter<DishWithPrice>))]
    [JsonPropertyName("Суп")]
    public DishWithPrice? Soup
    {
        get => _soup;
        set
        {
            if (value != null)
                Dishes.Add(value);
            _soup = value;
        }
    }

    [JsonPropertyName("Горячее")]
    [JsonConverter(typeof(JsonDishConverter<DishWithPrice>))]
    public DishWithPrice? FirstCourse
    {
        get => _firstCourse;
        set
        {
            if (value != null)
                Dishes.Add(value);
            _firstCourse = value;
        }
    }

}