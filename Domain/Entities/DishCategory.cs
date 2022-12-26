using System.Text.Json.Serialization;
using Domain.Common;

namespace Domain.Entities
{
    public class DishCategory : BaseEntity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Dish>? Dishes { get; set; }
    }
}
