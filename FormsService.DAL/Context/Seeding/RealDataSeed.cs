namespace FormsService.DAL.Context.Seeding;

public class RealDataSeed
{
    public static IEnumerable<object> GetAllDishes()
    {
        var allPossibledishes = new List<object>
        {
            new
            {
                Id = 1,
                Name = "Кобб с куриной грудкой"
            },
            new
            {
                Id = 2,
                Name = "Сельдь под шубой"
            },
            new
            {
                Id = 3,
                Name = "Грибной крем-суп с пшеничными гренками"
            },
            new
            {
                Id = 4,
                Name = "Финская сливочная уха"
            },
            new
            {
                Id = 5,
                Name = "Филе трески на подушке из кус-куса с соусом рататуй"
            },
            new
            {
                Id = 6,
                Name = "Фахитос из свинины с рисом тяхан"
            },
            new
            {
                Id = 7,
                Name = "Куриное фрикасе с молодым картофелем"
            }
        };
        return allPossibledishes;
    }

    public static IEnumerable<object> GetAllPersons()
    {
        var allPossiblePersons = new List<object>
        {
            new
            {
                Id = 1,
                Name = "Борисов"
            },
            new
            {
                Id = 2,
                Name = "Бухман"
            },
            new
            {
                Id = 3,
                Name = "Демидов"
            },
            new
            {
                Id = 4,
                Name = "Домашенко"
            },
            new
            {
                Id = 5,
                Name = "Менщиков"
            },
            new
            {
                Id = 6,
                Name = "Романова"
            },
            new
            {
                Id = 7,
                Name = "Смирнов"
            },
            new
            {
                Id = 8,
                Name = "Ковзик"
            },
            new
            {
                Id = 9,
                Name = "Цилюрик"
            }
        };
        return allPossiblePersons;
    }
}