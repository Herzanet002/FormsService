using MailService.Models.MenuModels;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace MailService.Models;

public class JsonDishConverter<T> : JsonConverter<T> where T : Dish
{
    private static Dish? CreateDish(string readerString)
    {
        //var regex = new Regex(@"[\w+\s*]+\/\s*\d+");

        var nameOfDish = readerString.Contains("-Нет-", StringComparison.OrdinalIgnoreCase)
            ? readerString.Trim()
            : readerString.Split("/")[0].Trim();

        var dishPrice = readerString.Contains("-Нет-", StringComparison.OrdinalIgnoreCase)
            ? 0
            : int.Parse(readerString.Split("/")[1]);

        return new Dish
        {
            Name = nameOfDish,
            Price = dishPrice
        };
    }

    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.GetString() is not { } str) return null;

        return CreateDish(str) as T;

    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"{value.Name + " / " + value.Price}");
    }
}