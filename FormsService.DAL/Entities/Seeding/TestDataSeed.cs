namespace FormsService.DAL.Entities.Seeding
{
    public class TestDataSeed
    {
        public static IEnumerable<Dish> GetTestDishes(int count)
        {
            for (var i = 1; i < count; i++)
            {
                yield return new Dish
                {
                    Id = i,
                    Name = $"Dish {i}"
                };
            }
        }

        public static IEnumerable<Person> GetTestPersons(int count)
        {
            for (var i = 1; i <= count; i++)
            {
                yield return new Person
                {
                    Id = i,
                    Name = $"Person {i}"
                };
            }
        }

        public static IEnumerable<Order> GetTestOrders(int count)
        {
            for (var i = 1; i < count; i++)
            {
                yield return new Order
                {
                    Id = i,
                    Person = GetTestPersons(2).First(),
                    Location = i % 2 == 0 ? Location.WithMe : Location.InCafe,
                    Dishes = GetTestDishes(3)
                };
            }
        }

        public static IEnumerable<DishOrder> GetTestDishOrder(int count)
        {
            for (var i = 1; i < count; i++)
            {
                yield return new DishOrder
                {
                    ID = i,
                    OrderID = i,
                    DishID = i,
                    Price = i*100
                };
            }
        }
    }
}
