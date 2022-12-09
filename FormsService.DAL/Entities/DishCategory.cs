using FormsService.DAL.Entities.Base;

namespace FormsService.DAL.Entities
{
    public class DishCategory : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Dish> Dish { get; set; }
    }
}
