using Domain.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MailService.Models;

public class JsonLocationConverter : JsonConverter<Location>
{
    public override Location? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return new Location { Name = reader.GetString() };
    }

    public override void Write(Utf8JsonWriter writer, Location value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}