using System.Text.Json;
using System.Text.Json.Serialization;
using FormsService.DAL.Entities;

namespace MailService.Models
{
    public class JsonPersonConverter<T> : JsonConverter<T> where T : Person
    {
        public static Person? CreatePerson(string readerString)
        {
            var splittedString = readerString.Split(' ');

            return splittedString.Length switch
            {
                1 => new Person { Name = splittedString[0], },
                2 => new Person { Name = splittedString[0], Surname = splittedString[1] },
                _ => null
            };
        }

        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.GetString() is not { } str) return null;
            return CreatePerson(str) as T;

        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
