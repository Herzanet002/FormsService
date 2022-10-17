using FormsService.DAL.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MailService.Models
{
    public class JsonPersonConverter<T> : JsonConverter<T> where T : Person
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.GetString() is not { } str) return null;
            return new Person
            {
                Name = str
            } as T;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}