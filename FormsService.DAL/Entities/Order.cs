using BaseEntity = FormsService.DAL.Entities.Base.BaseEntity;

namespace FormsService.DAL.Entities
{
    public class Order : BaseEntity
    {
        public Person Person { get; set; }
        public Location Location { get; set; }
        public IEnumerable<Dish> Dishes { get; set; }
    }
}
