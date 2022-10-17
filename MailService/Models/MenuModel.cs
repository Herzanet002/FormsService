using FormsService.DAL.Entities;
using FormsService.DAL.Entities.Base;
using System.Text.Json.Serialization;

namespace MailService.Models;

[Serializable]
public class MenuModel : BaseEntity, IEquatable<MenuModel>
{
    private Dish? _salad;
    private Dish? _soup;
    private Dish? _firstCourse;


    [JsonPropertyName("Сотрудник")]
    [JsonConverter(typeof(JsonPersonConverter<Person>))]
    public Person Person { get; set; }

    [JsonPropertyName("Где обедаю?")]
    public string Location { get; set; }

    public List<Dish> Dishes { get; set; } = new List<Dish>();


    [JsonPropertyName("Салат")]
    [JsonConverter(typeof(JsonDishConverter<Dish>))]
    public Dish? Salad
    {
        get => _salad;
        set
        {
            if(value != null) 
                Dishes.Add(value);
            _salad = value;
        }
    }

    [JsonConverter(typeof(JsonDishConverter<Dish>))]
    [JsonPropertyName("Суп")]
    public Dish? Soup
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
    [JsonConverter(typeof(JsonDishConverter<Dish>))]
    public Dish? FirstCourse
    {
        get => _firstCourse;
        set
        {
            if (value != null)
                Dishes.Add(value);
            _firstCourse = value;
        }
    }

    public bool Equals(MenuModel? other)
    {
        if (other is null) return false;
        return Equals(Salad.Name, other.Salad.Name)
               && Equals(Soup.Name, other.Soup.Name)
               && Equals(FirstCourse.Name, other.FirstCourse.Name)
               && Equals(Person.Name, other.Person.Name)
               && Location == other.Location;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((MenuModel)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_salad, _soup, _firstCourse, Person, Location, Dishes);
    }
}