using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace MailService.Models;

public class JsonDishConverter<T> : JsonConverter<T> where T : DishWithPrice
{
    private readonly Regex _patternRegex = new(@"[\w+\-*\s*]+\/\s*\d+");

    private DishWithPrice? CreateDish(string readerString)
    {
        var match = _patternRegex.Match(readerString);
        if (!match.Success) return null;

        var info = match.Value.Split("/");
        var dishName = info[0].TrimEnd();
        var dishPrice = int.Parse(info[1]);

        var dish = new DishWithPrice
        {
            Name = dishName,
            Price = dishPrice
        };
        return dish;
    }

    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.GetString() is not { } str) return null;

        return CreateDish(str) as T;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}