using FormsService.DAL.Entities.Base;
using System.Text.Json.Serialization;

namespace FormsService.DAL.Entities
{
    public class Dish : BaseEntity, IEquatable<Dish>
    {
        public string Name { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }

        [JsonIgnore]
        public virtual ICollection<DishOrder>? DishOrders { get; set; }


        public bool Equals(Dish? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Dish)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Orders, DishOrders);
        }
    }
}