using FormsService.DAL.Entities;

namespace FormsService.DAL.Context.Seeding
{
    public class TestDataSeed
    {
        private static readonly Random _random = new Random();

        public static IEnumerable<object> GetTestDishes(int count)
        {
            for (var i = 1; i < count; i++)
            {
                yield return new
                {
                    Id = i,
                    Name = $"Dish {i}"
                };
            }
        }

        public static IEnumerable<object> GetTestPersons(int count)
        {
            for (var i = 1; i < count; i++)
            {
                yield return new
                {
                    Id = i,
                    Name = $"Name {i}"
                };
            }
        }

        public static IEnumerable<object> GetTestOrders(int count)
        {
            for (var i = 1; i < count; i++)
            {
                yield return new
                {
                    Id = i,
                    PersonId = i,
                    Location = i % 2 == 0 ? Location.WithMe : Location.InCafe,
                    DateForming = DateTimeOffset.Now.AddDays(-_random.Next(1, 15))
                };
            }
        }

        public static IEnumerable<object> GetTestDishOrder(int count)
        {
            for (var i = 1; i < count; i++)
            {
                yield return new
                {
                    Id = i,
                    OrderID = i,
                    DishID = i,
                    Price = _random.Next(1, 15) * i * 10,
                    Count = i
                };
            }
        }
    }
}