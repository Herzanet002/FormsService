namespace Infrastructure.Persistence.Seeding;

public class TestDataSeed
{
    private static readonly Random Random = new();

    public static IEnumerable<object> GetTestDishes(int count)
    {
        for (var i = 1; i < count; i++)
            yield return new
            {
                Id = i,
                Name = $"Dish {i}"
            };
    }

    public static IEnumerable<object> GetTestPersons(int count)
    {
        for (var i = 1; i < count; i++)
            yield return new
            {
                Id = i,
                Name = $"Name {i}"
            };
    }

    public static IEnumerable<object> GetTestOrders(int count)
    {
        for (var i = 1; i < count; i++)
            yield return new
            {
                Id = i,
                PersonId = i,
                LocationId = i % 2 == 0 ? 1 : 2,
                DateForming = DateTimeOffset.Now.AddDays(-Random.Next(1, 15))
            };
    }

    public static IEnumerable<object> GetTestDishOrder(int count)
    {
        for (var i = 1; i < count; i++)
            yield return new
            {
                Id = i,
                OrderID = i,
                DishID = i,
                Price = Random.Next(1, 15) * i * 10,
                Count = i
            };
    }
}