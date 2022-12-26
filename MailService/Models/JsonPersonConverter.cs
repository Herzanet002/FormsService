using Domain.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MailService.Models
{
    public class JsonPersonConverter<T> : JsonConverter<T> where T : Person
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.GetString() is not { } personString) return null;
            return new Person
            {
                Name = personString.TrimEnd()
            } as T;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}