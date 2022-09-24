using MailService.Models.MenuModels;
using System.Text.Json.Serialization;


namespace MailService.Models
{
    [Serializable]
    public class MenuModel
    {
      
        [JsonPropertyName("Сотрудник")]
        public string Name { get; set; }

        [JsonPropertyName("Где обедаю?")]
        public string Location { get; set; }

        [JsonPropertyName("Салат")]
        [JsonConverter(typeof(JsonDishConverter<Salad>))]
        public Salad Salad { get; set; }

        [JsonPropertyName("Суп")]
        [JsonConverter(typeof(JsonDishConverter<Soup>))]
        public Soup Soup { get; set; }

        [JsonPropertyName("Горячее")]
        [JsonConverter(typeof(JsonDishConverter<FirstCourse>))]
        public FirstCourse FirstCourse { get; set; }
    }
}
