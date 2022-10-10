namespace FormsService.DAL.Entities
{
    public class DishOrder
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public Dish Dish { get; set; }
        public int DishID { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }

    }
}
