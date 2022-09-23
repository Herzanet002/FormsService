using System.Text.Json.Serialization;

namespace MailService.Models
{
    [Serializable]
    public class MenuModel
    {
        public int Id { get; set; }

        [JsonPropertyName("Сотрудник")]
        public string Name { get; set; }

        [JsonPropertyName("Где обедаю?")]
        public string Location { get; set; }

        [JsonPropertyName("Салат")]
        public string Salad { get; set; }

        [JsonPropertyName("Суп")]
        public string Soup { get; set; }
        [JsonPropertyName("Горячее")]
        public string FirstCourse { get; set; }

    }
}
