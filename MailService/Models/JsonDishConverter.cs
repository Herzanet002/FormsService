using MailService.Models.MenuModels;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MailService.Models;

public class JsonDishConverter<T> : JsonConverter<T> where T : Dish
{
    private static Dish? CreateDishInheritor(string readerString, string typeOfDish)
    {
        var nameOfDish = readerString.Contains("нет", StringComparison.OrdinalIgnoreCase)
            ? readerString.Replace("-", string.Empty).Trim()
            : readerString.Split("/")[0].Trim();

        var dishPrice = readerString.Contains("нет", StringComparison.OrdinalIgnoreCase)
            ? 0
            : int.Parse(readerString.Split("/")[1]);

        return typeOfDish switch
        {
            nameof(Salad) => new Salad { Name = nameOfDish, Price = dishPrice },
            nameof(Soup) => new Soup { Name = nameOfDish, Price = dishPrice },
            nameof(FirstCourse) => new FirstCourse { Name = nameOfDish, Price = dishPrice },
            _ => null
        };
    }

    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.GetString() is not { } str) return null;

        return CreateDishInheritor(str, typeToConvert.Name) as T;

    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"{value.Name + " / " + value.Price}");
    }
}