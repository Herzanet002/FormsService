using System.Text.Json.Serialization;
using BaseEntity = FormsService.DAL.Entities.Base.BaseEntity;

namespace FormsService.DAL.Entities
{
    public class Order : BaseEntity
    {
        public Person Person { get; set; }
        public Location Location { get; set; }
        public DateTimeOffset DateForming { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }

        [JsonIgnore]
        public virtual ICollection<DishOrder>? DishOrders { get; set; }
    }
}