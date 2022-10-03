using FormsService.DAL.Entities.Base;

namespace FormsService.DAL.Entities
{
    public class Dish : BaseEntity
    {
        public string Title { get; set; }
        public int Price { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}