using FormsService.DAL.Entities;

namespace FormsService.DAL.Context.Seeding;

public class RealDataSeed
{
    public static IEnumerable<Dish> GetAllDishes()
    {
        var allPossibledishes = new List<Dish>
        {
            new()
            {
                Id = 1,
                Name = "Кобб с куриной грудкой",
                DishCategoryId=1,
                DishPrice = 100

            },
            new()
            {
                Id = 2,
                Name = "Сельдь под шубой",
                DishCategoryId=1,
                DishPrice = 120
            },
            new()
            {
                Id = 3,
                Name = "Грибной крем-суп с пшеничными гренками",
                DishCategoryId=2,
                DishPrice = 150
            },
            new()
            {
                Id = 4,
                Name = "Финская сливочная уха",
                DishCategoryId=2,
                DishPrice = 140
            },
            new()
            {
                Id = 5,
                Name = "Филе трески на подушке из кус-куса с соусом рататуй",
                DishCategoryId=3,
                DishPrice = 180
            },
            new()
            {
                Id = 6,
                Name = "Фахитос из свинины с рисом тяхан",
                DishCategoryId=3,
                DishPrice = 170
            },
            new()
            {
                Id = 7,
                Name = "Куриное фрикасе с молодым картофелем",
                DishCategoryId=3,
                DishPrice = 165
            }
        };
        return allPossibledishes;
    }

    public static IEnumerable<Person> GetAllPersons()
    {
        var allPossiblePersons = new List<Person>
        {
            new()
            {
                Id = 1,
                Name = "Борисов"
            },
            new()
            {
                Id = 2,
                Name = "Бухман"
            },
            new()
            {
                Id = 3,
                Name = "Демидов"
            },
            new()
            {
                Id = 4,
                Name = "Домашенко"
            },
            new()
            {
                Id = 5,
                Name = "Менщиков"
            },
            new()
            {
                Id = 6,
                Name = "Романова"
            },
            new()
            {
                Id = 7,
                Name = "Смирнов"
            },
            new()
            {
                Id = 8,
                Name = "Ковзик"
            },
            new()
            {
                Id = 9,
                Name = "Цилюрик"
            }
        };
        return allPossiblePersons;
    }

    public static IEnumerable<DishCategory> GetAllDishCategories()
    {
        var categoriesList = new List<DishCategory>
        {
            new()
            {
                Id = 1,
                Name = "Салат"
            },
            new()
            {
                Id = 2,
                Name = "Суп"
            },
            new()
            {
                Id = 3,
                Name = "Горячее"
            }
        };
        return categoriesList;
    }
}