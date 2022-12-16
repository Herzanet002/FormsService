using System.Text.Json.Serialization;
using FormsService.DAL.Entities.Base;

namespace FormsService.DAL.Entities
{
    public class DishCategory : BaseEntity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Dish>? Dishes { get; set; }
    }
}
